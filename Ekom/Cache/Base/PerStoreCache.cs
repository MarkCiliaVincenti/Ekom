using Ekom.Helpers;
using Ekom.Interfaces;
using Ekom.Models;
using Ekom.Models.Abstractions;
using Ekom.Models.Data;
using Examine;
using Examine.SearchCriteria;
using log4net;
using Newtonsoft.Json;
using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Linq;
using Umbraco.Core.Models;

namespace Ekom.Cache
{
    /// <summary>
    /// Per store caching for entities of generic type TItem
    /// </summary>
    /// <typeparam name="TItem">Type of entity to cache</typeparam>
    abstract class PerStoreCache<TItem> : ICache, IPerStoreCache, IPerStoreCache<TItem>
        where TItem : class
    {
        protected Configuration _config;
        protected ILog _log;
        protected IBaseCache<IStore> _storeCache;
        protected IPerStoreFactory<TItem> _objFac;

        protected ExamineManagerBase _examineManager => Configuration.container.GetInstance<ExamineManagerBase>();

        public PerStoreCache(
            Configuration config,
            IBaseCache<IStore> storeCache,
            IPerStoreFactory<TItem> objFac
        )
        {
            _config = config;
            _storeCache = storeCache;
            _objFac = objFac;
        }

        /// <summary>
        /// Umbraco Node Alias name used in Examine search
        /// </summary>
        public abstract string NodeAlias { get; }

        /// <summary>
        /// Concurrent dictionaries per store
        /// </summary>
        public virtual ConcurrentDictionary<string, ConcurrentDictionary<Guid, TItem>> Cache { get; }
         = new ConcurrentDictionary<string, ConcurrentDictionary<Guid, TItem>>();

        /// <summary>
        /// Class indexer
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public ConcurrentDictionary<Guid, TItem> this[string index] => Cache[index];

        public virtual void FillCache()
        {
            FillCache(null);
        }

        /// <summary>
        /// Base Fill cache method appropriate for most derived caches
        /// </summary>
        /// <param name="storeParam">
        /// This parameter is supplied when adding a store at runtime, 
        /// triggering the given stores filling
        /// </param>
        public virtual void FillCache(IStore storeParam = null)
        {
            var searcher = _examineManager.SearchProviderCollection[_config.ExamineSearcher];

            if (searcher != null && !string.IsNullOrEmpty(NodeAlias))
            {
                var stopwatch = new Stopwatch();

                stopwatch.Start();

                _log.Debug("Starting to fill...");
                int count = 0;

                try
                {
                    ISearchCriteria searchCriteria = searcher.CreateSearchCriteria();
                    IBooleanOperation query = searchCriteria.NodeTypeAlias(NodeAlias); // Gaui
                    ISearchResults results = searcher.Search(query.Compile());

                    if (storeParam == null) // Startup initialization
                    {
                        foreach (var store in _storeCache.Cache.Select(x => x.Value))
                        {
                            count += FillStoreCache(store, results);
                        }
                    }
                    else // Triggered with dynamic addition/removal of store
                    {
                        count += FillStoreCache(storeParam, results);
                    }
                }
                catch (Exception ex)
                {
                    _log.Error("Filling per store cache Failed!", ex);
                }

                stopwatch.Stop();

                _log.Debug("Finished filling cache with " + count + " items. Time it took to fill: " + stopwatch.Elapsed);
            }
            else
            {
                _log.Error($"No examine search found with the name {_config.ExamineSearcher}, Can not fill category cache.");
            }
        }

        /// <summary>
        /// Fill the given stores cache of TItem
        /// </summary>
        /// <param name="store">The current store being filled of TItem</param>
        /// <param name="results">Examine search results</param>
        /// <returns>Count of items added</returns>
        protected virtual int FillStoreCache(IStore store, ISearchResults results)
        {
            int count = 0;

            var curStoreCache = Cache[store.Alias] = new ConcurrentDictionary<Guid, TItem>();

            foreach (var r in results)
            {
                try
                {
                    // Traverse up parent nodes, checking disabled status and published status
                    if (!r.IsItemDisabled(store))
                    {
                        var item = _objFac?.Create(r, store)
                            ?? (TItem)Activator.CreateInstance(typeof(TItem), r, store);

                        if (item != null)
                        {
                            count++;

                            var itemKey = Guid.Parse(r.Fields["key"]);
                            curStoreCache[itemKey] = item;
                        }
                    }
                }
                catch (Exception ex) // Skip on fail
                {
                    _log.Error("Error on adding item with id: " + r.Id + " from Examine in Store: " + store.Alias, ex);
                }
            }

            return count;
        }

        public void AddOrReplaceFromCache(Guid id, Store store, TItem newCacheItem)
        {
            Cache[store.Alias][id] = newCacheItem;
        }

        public bool RemoveItemFromCache(IStore store, Guid id)
        {
            return Cache[store.Alias].TryRemove(id, out TItem i);
        }

        /// <summary>
        /// Adds or replaces an item from all store caches
        /// </summary>
        public void AddOrReplaceFromAllCaches(IContent node)
        {
            foreach (var store in _storeCache.Cache)
            {
                try
                {
                    if (!node.IsItemDisabled(store.Value))
                    {
                        var item = _objFac?.Create(node, store.Value)
                            ?? (TItem)Activator.CreateInstance(typeof(TItem), node, store.Value);

                        if (item != null) Cache[store.Value.Alias][node.Key] = item;
                    }
                }
                catch (Exception ex) // Skip on fail
                {
                    _log.Error("Error on Add/Replacing item with id: " + node.Id + " in store: " + store.Value.Alias, ex);
                }
            }
        }

            /// <summary>
            /// Removes an item from all store caches
            /// </summary>
            public void RemoveItemFromAllCaches(Guid id)
        {
            TItem i = default(TItem);

            foreach (var store in _storeCache.Cache)
            {
                Cache[store.Value.Alias].TryRemove(id, out i);
            }
        }

        /// <summary>
        /// <see cref="ICache"/> implementation,
        /// handles addition of nodes when umbraco events fire
        /// </summary>
        public virtual void AddReplace(IContent node)
        {
            AddOrReplaceFromAllCaches(node);
        }

        public virtual void AddReplace(CouponData coupon)
        {
        }
        public virtual void Remove(CouponData coupon)
        {
        }


        /// <summary>
        /// <see cref="ICache"/> implementation,
        /// handles removal of nodes when umbraco events fire
        /// </summary>
        public virtual void Remove(Guid id)
        {
            RemoveItemFromAllCaches(id);
        }
    }
}
