namespace STM.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.ChangeTracking;
    using Microsoft.Extensions.Caching.Distributed;
    using Microsoft.Extensions.Caching.Memory;
    using STM.Common.Constants;

    public class UnitOfWork<TContext> : IUnitOfWork<TContext>
        where TContext : DbContext, IDisposable
    {
        private readonly Dictionary<Type, object> _repositories = new Dictionary<Type, object>();

        public UnitOfWork(TContext context)
        {
            this.Context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public UnitOfWork(TContext context, IDistributedCache distributedCache, IMemoryCache memoryCache)
        {
            this.Context = context ?? throw new ArgumentNullException(nameof(context));
            this.DistributedCache = distributedCache;
            this.MemoryCache = memoryCache;
        }

        public TContext Context { get; }

        public Guid? CurrentUserEntityId { get; set; }

        public IMemoryCache MemoryCache { get; set; }

        public IDistributedCache DistributedCache { get; set; }

        public IRepositoryAsync<TEntity> GetRepositoryAsync<TEntity>()
             where TEntity : class
        {
            var type = typeof(RepositoryAsync<TEntity>);
            if (!this._repositories.ContainsKey(type))
            {
                this._repositories[type] = new RepositoryAsync<TEntity>(this.Context);
            }

            return (IRepositoryAsync<TEntity>)this._repositories[type];
        }

        public IRepositoryReadOnlyAsync<TEntity> GetRepositoryReadOnlyAsync<TEntity>()
            where TEntity : class
        {
            var type = typeof(RepositoryReadOnlyAsync<TEntity>);
            if (!this._repositories.ContainsKey(type))
            {
                this._repositories[type] = new RepositoryReadOnlyAsync<TEntity>(this.Context);
            }

            return (IRepositoryReadOnlyAsync<TEntity>)this._repositories[type];
        }

        public IMemoryCacheRepository GetMemoryCacheRepository<TEntity>()
            where TEntity : class
        {
            var type = typeof(MemoryCacheRepository);
            if (!this._repositories.ContainsKey(type))
            {
                this._repositories[type] = new MemoryCacheRepository(this.MemoryCache);
            }

            return (IMemoryCacheRepository)this._repositories[type];
        }

        public IDistributedCacheRepository GetDistributedCacheRepository<TEntity>()
            where TEntity : class
        {
            var type = typeof(DistributedCacheRepository);
            if (!this._repositories.ContainsKey(type))
            {
                this._repositories[type] = new DistributedCacheRepository(this.DistributedCache);
            }

            return (IDistributedCacheRepository)this._repositories[type];
        }

        public int SaveChanges()
        {
            return this.Context.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            this.SaveChangesInternal();
            return await this.Context.SaveChangesAsync();
        }

        public void Dispose()
        {
            this.Context?.Dispose();
            GC.SuppressFinalize(this);
        }

        private void SaveChangesInternal()
        {
            this.Context.ChangeTracker.DetectChanges();
            var entries = this.Context.ChangeTracker.Entries()
                .Where(x => (x.State == EntityState.Added)
                    || (x.State == EntityState.Modified));

            this.SaveChangesInternal(entries, EntityState.Added);
            this.SaveChangesInternal(entries, EntityState.Modified);
        }

        private void SaveChangesInternal(IEnumerable<EntityEntry> entries, EntityState state)
        {
            PropertyEntry prop;

            // Enforce type defaults for all entities
            foreach (var item in entries)
            {
                foreach (var p in item.Properties)
                {
                    if (p.CurrentValue == null)
                    {
                        continue;
                    }

                    switch (p.Metadata.ClrType.Name)
                    {
                        case "String": // Replace all empty strings with null
                            var emptyString = string.IsNullOrWhiteSpace(p.CurrentValue.ToString());
                            p.CurrentValue = emptyString ? null : p.CurrentValue;
                            break;
                    }
                }
            }

            foreach (var item in entries.Where(t => t.State == state))
            {
                if (state == EntityState.Added)
                {
                    // CreatedDate
                    prop = item.Properties.FirstOrDefault(p => p.Metadata.Name == ColumnNames.CreatedAt);
                    if (prop != null)
                    {
                        prop.CurrentValue = DateTime.Now;

                        // CreatedBy
                        if (this.CurrentUserEntityId != null)
                        {
                            prop = item.Properties.FirstOrDefault(p => p.Metadata.Name == ColumnNames.CreatedById);
                            if (prop != null)
                            {
                                prop.CurrentValue = this.CurrentUserEntityId;
                            }
                        }
                    }
                }

                // UpdatedAt
                prop = item.Properties.FirstOrDefault(p => p.Metadata.Name == ColumnNames.UpdatedAt);
                if (prop != null)
                {
                    prop.CurrentValue = DateTime.Now;

                    // UpdatedById
                    if (this.CurrentUserEntityId != null)
                    {
                        prop = item.Properties.FirstOrDefault(p => p.Metadata.Name == ColumnNames.UpdatedById);
                        if (prop != null)
                        {
                            prop.CurrentValue = this.CurrentUserEntityId;
                        }
                    }
                }

                // Trim String Entries Before Saving
                var propertyValues = item.Properties.Where(p => (p.CurrentValue != null) && p.CurrentValue.GetType() == typeof(string) && !string.IsNullOrEmpty(Convert.ToString(p.CurrentValue)));
                foreach (PropertyEntry propertyValue in propertyValues)
                {
                    propertyValue.CurrentValue = propertyValue.CurrentValue.ToString().Trim();
                }
            }
        }
    }
}