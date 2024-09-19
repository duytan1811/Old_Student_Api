namespace STM.Repositories
{
    public interface IMemoryCacheRepository
    {
        void SetObject<T>(string key, T value);

        T GetObject<T>(string key);

        void RemoveCache(string key);
    }
}