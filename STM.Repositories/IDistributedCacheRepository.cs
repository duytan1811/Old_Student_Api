namespace STM.Repositories
{
    using System.Threading.Tasks;

    public interface IDistributedCacheRepository
    {
        void SetObject<T>(string key, T value);

        Task SetObjectAsync<T>(string key, T value);

        T GetObject<T>(string key);

        Task<T> GetObjectAsync<T>(string key);

        void RemoveCache(string key);

        Task RemoveCacheAsync(string key);

        void RemoveAll();

        void SetCacheRelatedKey(string key, string relatedKey);
    }
}
