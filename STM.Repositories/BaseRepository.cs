namespace STM.Repositories
{
    using System;
    using Microsoft.EntityFrameworkCore;

    public abstract class BaseRepository<T>
        where T : class
    {
        protected BaseRepository(DbContext context)
        {
            this.DbContext = context ?? throw new ArgumentException(nameof(context));
            this.DbSet = this.DbContext.Set<T>();
        }

        public DbSet<T> DbSet { get; }

        public DbContext DbContext { get; }
    }
}