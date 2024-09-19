namespace STM.DataAccess.Contexts
{
    using System;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Diagnostics;
    using Microsoft.Extensions.Logging;

    public class STMDbContextInMemory : IDisposable
    {
        public static readonly LoggerFactory DbContextLoggerFactory = new LoggerFactory(new[] { new Microsoft.Extensions.Logging.Debug.DebugLoggerProvider() });

        private bool _disposed;

        public STMDbContext Context => this.InMemoryContext();

        public void Dispose() // Implement IDisposable
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    // called via myClass.Dispose().
                    // OK to use any private object references
                }

                // Release unmanaged resources.
                // Set large fields to null.
                this._disposed = true;
            }
        }

        private STMDbContext InMemoryContext()
        {
            var options = new DbContextOptionsBuilder<STMDbContext>()
                .UseInMemoryDatabase(0.ToString())
                .ConfigureWarnings(config => config.Ignore(InMemoryEventId.TransactionIgnoredWarning))
                .EnableSensitiveDataLogging()
                .UseLoggerFactory(DbContextLoggerFactory)
                .Options;
            return new STMDbContext(options);
        }
    }
}
