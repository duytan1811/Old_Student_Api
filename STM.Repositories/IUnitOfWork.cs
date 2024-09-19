namespace STM.Repositories
{
    using System;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;

    public interface IUnitOfWork : IDisposable
    {
        Guid? CurrentUserEntityId { get; set; }

        IMemoryCacheRepository GetMemoryCacheRepository<TEntity>()
            where TEntity : class;

        IDistributedCacheRepository GetDistributedCacheRepository<TEntity>()
            where TEntity : class;

        IRepositoryAsync<TEntity> GetRepositoryAsync<TEntity>()
            where TEntity : class;

        IRepositoryReadOnlyAsync<TEntity> GetRepositoryReadOnlyAsync<TEntity>()
            where TEntity : class;

        int SaveChanges();

        Task<int> SaveChangesAsync();
    }

    public interface IUnitOfWork<TContext> : IUnitOfWork
        where TContext : DbContext
    {
        TContext Context { get; }
    }
}