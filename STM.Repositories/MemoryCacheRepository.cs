namespace STM.Repositories
{
    using System;
    using Microsoft.Extensions.Caching.Memory;
    using STM.Common.Constants;

    public class MemoryCacheRepository : IMemoryCacheRepository
    {
        private readonly IMemoryCache _memoryCache;

        public MemoryCacheRepository(IMemoryCache memoryCache)
        {
            this._memoryCache = memoryCache;
        }

        /// <summary>
        /// Save data in cache.
        /// </summary>
        /// <param name="key">Using a key to save cache.</param>
        /// <param name="value">Save a object to cache.</param>
        /// <typeparam name="T">Generic classes.</typeparam>
        public void SetObject<T>(string key, T value)
        {
            if (!this.UseMemoryCache())
            {
                return;
            }

            // Create cache options
            var memoryCacheEntryOptions = new MemoryCacheEntryOptions()
                .SetSlidingExpiration(TimeSpan.FromMinutes(CacheSettings.SetSlidingExpiration))
                .SetAbsoluteExpiration(TimeSpan.FromMinutes(CacheSettings.SetAbsoluteExpiration));

            // Save data in cache.
            this._memoryCache.Set(key, value, memoryCacheEntryOptions);
        }

        /// <summary>
        /// Get data from cache.
        /// </summary>
        /// <param name="key">Using a key to get data from cache.</param>
        /// <typeparam name="T">Generic classes.</typeparam>
        /// <returns>Represents a single operation that return a Generic class.</returns>
        public T GetObject<T>(string key)
        {
            T value = default(T);

            if (!this.UseMemoryCache())
            {
                return value;
            }

            this._memoryCache.TryGetValue<T>(key, out value);

            return value;
        }

        /// <summary>
        /// Remove data in cache.
        /// </summary>
        /// <param name="key">Using a key to remove cache.</param>
        public void RemoveCache(string key)
        {
            if (!this.UseMemoryCache())
            {
                return;
            }

            this._memoryCache.Remove(key);
        }

        private bool UseMemoryCache()
        {
            if (this._memoryCache == null)
            {
                return false;
            }

            return true;
        }
    }
}