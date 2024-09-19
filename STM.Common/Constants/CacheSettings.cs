namespace STM.Common.Constants
{
    public static class CacheSettings
    {
        // The configuration used to connect to Redis.
        public const string DistributedRedisConfiguration = "127.0.0.1";

        // The Redis instance name.
        public const string DistributedRedisInstanceName = "Viettel_QLHS";

        /// <summary>
        /// Keep in cache for this time, reset time if accessed.
        /// The minute value.
        /// </summary>
        public const int SetSlidingExpiration = 5;

        /// <summary>
        /// Remove from cache after this time, regardless of sliding expiration.
        /// The minute value.
        /// </summary>
        public const int SetAbsoluteExpiration = 15;

        public const string CacheRelatedKey = "CacheRelatedKey";

        public const int TokenExpirationTime = 1440; // minutes
    }
}