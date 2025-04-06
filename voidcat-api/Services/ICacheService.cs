using Microsoft.Extensions.Caching.Memory;

namespace voidcat_api.Services
{
    public interface ICacheService
    {
        T Get<T>(string cacheKey);
        void Set<T>(string cacheKey, T item, TimeSpan absoluteExpiration, TimeSpan slidingExpiration);
        void Remove(string cacheKey);
    }

    public class CacheService : ICacheService
    {
        private readonly IMemoryCache _cache;

        public CacheService(IMemoryCache cache)
        {
            _cache = cache;
        }

        public T Get<T>(string cacheKey)
        {
            _cache.TryGetValue(cacheKey, out T cacheItem);
            return cacheItem;
        }

        public void Set<T>(string cacheKey, T item, TimeSpan absoluteExpiration, TimeSpan slidingExpiration)
        {
            var cacheEntryOptions = new MemoryCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = absoluteExpiration,
                SlidingExpiration = slidingExpiration
            };

            _cache.Set(cacheKey, item, cacheEntryOptions);
        }

        public void Remove(string cacheKey)
        {
            _cache.Remove(cacheKey);
        }
    }
}