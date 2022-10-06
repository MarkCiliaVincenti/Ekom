using Ekom.Services;
using Umbraco.Cms.Core.Cache;

namespace Ekom.U10.Services
{
    public class CacheService : ICacheService
    {
        readonly IRequestCache _requestCache;

        public CacheService(AppCaches appCaches)
        {
            _requestCache = appCaches.RequestCache;
        }
        public TValue Get<TValue>(string key)
        {
            return (TValue)_requestCache.Get(key);
        }
        public void Add<TValue>(string key, TValue value)
        {
            _requestCache.Set(key, value);
        }

        public void Remove(string key)
        {
            _requestCache.Remove(key);
        }

        public TValue GetOrAdd<TValue>(string key, Func<TValue> add)
        {
            return (TValue)_requestCache.Get(key, () => add());
        }
    }
}
