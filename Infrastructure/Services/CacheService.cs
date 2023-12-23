using Core.Interfaces;
using Microsoft.Extensions.Caching.Memory;

namespace Infrastructure.Services
{
    public class CacheService<TEntity> : ICacheService<TEntity>
       where TEntity : class
    {
        private readonly IMemoryCache _memoryCache;
        public CacheService(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public void SetItems(string cacheKey, List<TEntity> datas)
        {
            var cacheEntryOptions = new MemoryCacheEntryOptions()
               .SetSlidingExpiration(TimeSpan.FromDays(1));
            _memoryCache.Set(cacheKey, datas, cacheEntryOptions);
        }

        public void SetItem(string cacheKey, TEntity data)
        {
            var cacheEntryOptions = new MemoryCacheEntryOptions()
             .SetSlidingExpiration(TimeSpan.FromDays(1));
            _memoryCache.Set(cacheKey, data, cacheEntryOptions);
        }

        public List<TEntity> GetItems(string cacheKey)
        {
            _memoryCache.TryGetValue(cacheKey, out IEnumerable<TEntity> dataCached);
            return dataCached == null ? null : dataCached.ToList();
        }

        public TEntity GetItem(string cacheKey)
        {
            _memoryCache.TryGetValue(cacheKey, out TEntity dataCached);
            return dataCached;
        }
    }
}
