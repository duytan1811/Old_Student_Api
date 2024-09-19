namespace STM.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.Extensions.Caching.Distributed;
    using Microsoft.Extensions.Logging;
    using Newtonsoft.Json;
    using STM.Common.Constants;
    using STM.Common.Serialization;

    public class DistributedCacheRepository : IDistributedCacheRepository
    {
        private const string DistributedCacheKeys = "DistributedCacheKeys";
        private readonly IDistributedCache _distributedCache;
        private readonly JsonSerializerSettings _serializerSettings;
        private readonly ILogger<DistributedCacheRepository> _logger;

        public DistributedCacheRepository(IDistributedCache distributedCache)
        {
            this._distributedCache = distributedCache;
            this._logger = new LoggerFactory().CreateLogger<DistributedCacheRepository>();
            this._serializerSettings = new JsonSerializerSettings()
            {
                PreserveReferencesHandling = PreserveReferencesHandling.Objects,
                Formatting = Formatting.Indented,
                ContractResolver = new NoVirtualMembersContractResolver(),
            };
        }

        public static string GetCacheKey(string key)
        {
            return key.Replace(" ", string.Empty, StringComparison.OrdinalIgnoreCase).Trim().ToLower();
        }

        /// <summary>
        /// Save data in cache.
        /// </summary>
        /// <param name="key">Using a key to save cache.</param>
        /// <param name="value">Save a object to cache.</param>
        /// <typeparam name="T">Generic classes.</typeparam>
        public void SetObject<T>(string key, T value)
        {
            try
            {
                key = GetCacheKey(key);
                if (!this.HasDistributedCache(key))
                {
                    return;
                }

                // Create cache options
                DistributedCacheEntryOptions distributedCacheEntryOptions = new DistributedCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromMinutes(CacheSettings.SetSlidingExpiration))
                    .SetAbsoluteExpiration(TimeSpan.FromMinutes(CacheSettings.SetAbsoluteExpiration));

                this._distributedCache.SetString(key, JsonConvert.SerializeObject(value, this._serializerSettings), distributedCacheEntryOptions);

                this.UpdateDistributedCacheKey(key);
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex, ex.Message);
            }
        }

        /// <summary>
        /// Save data in cache.
        /// </summary>
        /// <param name="key">Using a key to save cache.</param>
        /// <param name="value">Save a object to cache.</param>
        /// <typeparam name="T">Generic classes.</typeparam>
        /// <returns>Represents a single operation that does not return a value.</returns>
        public async Task SetObjectAsync<T>(string key, T value)
        {
            key = GetCacheKey(key);
            if (!this.HasDistributedCache(key))
            {
                return;
            }

            // Create cache options
            DistributedCacheEntryOptions distributedCacheEntryOptions = new DistributedCacheEntryOptions()
                .SetSlidingExpiration(TimeSpan.FromMinutes(CacheSettings.SetSlidingExpiration))
                .SetAbsoluteExpiration(TimeSpan.FromMinutes(CacheSettings.SetAbsoluteExpiration));

            await this._distributedCache.SetStringAsync(key, JsonConvert.SerializeObject(value, this._serializerSettings), distributedCacheEntryOptions).ConfigureAwait(false);

            this.UpdateDistributedCacheKey(key);
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

            try
            {
                key = GetCacheKey(key);
                if (!this.HasDistributedCache(key))
                {
                    return value;
                }

                string valueString = this._distributedCache.GetString(key);
                if (valueString != null)
                {
                    value = JsonConvert.DeserializeObject<T>(valueString);
                }
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex, ex.Message);
            }

            return value;
        }

        /// <summary>
        /// Get data from cache.
        /// </summary>
        /// <param name="key">Using a key to get data from cache.</param>
        /// <typeparam name="T">Generic classes.</typeparam>
        /// <returns>Represents a single operation that return a Generic class.</returns>
        public async Task<T> GetObjectAsync<T>(string key)
        {
            T value = default(T);

            key = GetCacheKey(key);
            if (!this.HasDistributedCache(key))
            {
                return value;
            }

            string valueString = await this._distributedCache.GetStringAsync(key).ConfigureAwait(false);
            if (value != null)
            {
                value = JsonConvert.DeserializeObject<T>(valueString);
            }

            return value;
        }

        /// <summary>
        /// Remove data in cache.
        /// </summary>
        /// <param name="key">Using a key to remove cache.</param>
        public void RemoveCache(string key)
        {
            key = GetCacheKey(key);
            if (!this.HasDistributedCache(key))
            {
                return;
            }

            this._distributedCache.Remove(key);
        }

        /// <summary>
        /// Remove data in cache.
        /// </summary>
        /// <param name="key">Using a key to remove cache.</param>
        /// <returns>Represents a single operation that does not return a value.</returns>
        public async Task RemoveCacheAsync(string key)
        {
            key = GetCacheKey(key);
            if (!this.HasDistributedCache(key))
            {
                return;
            }

            await this._distributedCache.RemoveAsync(key).ConfigureAwait(false);
        }

        public void SetCacheRelatedKey(string key, string relatedKey)
        {
            Dictionary<string, Dictionary<string, string>> relatedKeys = this.GetCacheRelatedKey();
            Dictionary<string, string> subKeys = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

            key = GetCacheKey(key);
            if (relatedKeys.ContainsKey(key))
            {
                subKeys = relatedKeys[key];
                if (subKeys.ContainsKey(relatedKey))
                {
                    return;
                }

                subKeys.Add(relatedKey, string.Empty);
            }
            else
            {
                subKeys.Add(relatedKey, string.Empty);
                relatedKeys.Add(key, subKeys);
            }

            // Save data in cache.
            this.SetObject(CacheSettings.CacheRelatedKey, relatedKeys);
        }

        public void RemoveAll()
        {
            if (this._distributedCache == null)
            {
                return;
            }

            Dictionary<string, string> dictionaryCacheKeys = this.GetDictionaryCacheKeys();
            foreach (string key in dictionaryCacheKeys.Keys)
            {
                this._distributedCache.Remove(key);
            }
        }

        private Dictionary<string, Dictionary<string, string>> GetCacheRelatedKey()
        {
            Dictionary<string, Dictionary<string, string>> relatedKeys = new Dictionary<string, Dictionary<string, string>>(StringComparer.OrdinalIgnoreCase);

            if (this._distributedCache == null)
            {
                return relatedKeys;
            }

            string valueString = this._distributedCache.GetString(CacheSettings.CacheRelatedKey);
            if (!string.IsNullOrEmpty(valueString))
            {
                relatedKeys = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, string>>>(valueString);
            }

            return relatedKeys;
        }

        private bool HasDistributedCache(string key)
        {
            if (string.IsNullOrEmpty(key) || (this._distributedCache == null))
            {
                return false;
            }

            return true;
        }

        private void UpdateDistributedCacheKey(string key)
        {
            if (!this.HasDistributedCache(key))
            {
                return;
            }

            Dictionary<string, string> dictionaryCacheKeys = this.GetDictionaryCacheKeys();
            if (!dictionaryCacheKeys.ContainsKey(key))
            {
                dictionaryCacheKeys.Add(key, key);
            }

            // Create cache options
            DistributedCacheEntryOptions distributedCacheEntryOptions = new DistributedCacheEntryOptions()
                .SetSlidingExpiration(TimeSpan.FromMinutes(CacheSettings.SetSlidingExpiration));

            this._distributedCache.SetString(DistributedCacheKeys, JsonConvert.SerializeObject(dictionaryCacheKeys, this._serializerSettings), distributedCacheEntryOptions);
        }

        private Dictionary<string, string> GetDictionaryCacheKeys()
        {
            Dictionary<string, string> dictionaryCacheKeys = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

            string valueString = this._distributedCache.GetString(DistributedCacheKeys);
            if (!string.IsNullOrEmpty(valueString))
            {
                dictionaryCacheKeys = JsonConvert.DeserializeObject<Dictionary<string, string>>(valueString);
            }

            return dictionaryCacheKeys;
        }
    }
}
