using Ekom.Core.Cache;
using Ekom.Core.Exceptions;
using Ekom.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Ekom.Core.Services
{
    class StoreService : IStoreService
    {
        readonly IStoreDomainCache _domainCache;
        readonly IBaseCache<IStore> _storeCache;

        /// <summary>
        /// ctor
        /// </summary>
        public StoreService(
            IStoreDomainCache domainCache,
            IBaseCache<IStore> storeCache
        )
        {
            _domainCache = domainCache;
            _storeCache = storeCache;
        }

        public IStore GetStoreByDomain(string domain = "")
        {
            IStore store = null;

            if (!string.IsNullOrEmpty(domain))
            {
                domain = domain.TrimEnd('/');

                var storeDomain
                    = _domainCache.Cache
                                      .FirstOrDefault
                                          (x => domain.Equals(x.Value.DomainName, System.StringComparison.InvariantCultureIgnoreCase))
                                      .Value;

                if (storeDomain != null)
                {
                    store = _storeCache.Cache
                                      .FirstOrDefault
                                        (x => x.Value.StoreRootNode == storeDomain.RootContentId)
                                      .Value;
                }
            }

            if (store == null)
            {
                store = GetAllStores().FirstOrDefault();
            }

            if (store == null)
            {
                throw new Exception("No store found in cache.");
            }

            return store;
        }

        public IStore GetStoreByAlias(string alias)
        {
            var store = _storeCache.Cache
                             .FirstOrDefault(x => x.Value.Alias.Equals(alias, StringComparison.InvariantCultureIgnoreCase))
                             .Value;
            // If store is not found by alias then return first store
            return store ?? _storeCache.Cache.FirstOrDefault().Value
                ?? throw new StoreNotFoundException("Unable to find any stores!");
        }

        public IStore GetStoreFromCache()
        {
            var r = _reqCache.GetCacheItem<ContentRequest>("ekmRequest");

            return r?.Store ?? GetAllStores().FirstOrDefault();
        }

        public IEnumerable<IStore> GetAllStores()
        {
            return _storeCache.Cache.Select(x => x.Value).OrderBy(x => x.SortOrder);
        }

    }
}
