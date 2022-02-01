using Ekom.Interfaces;
using Ekom.Models.Discounts;
using Ekom.Utilities;
using Examine;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using Umbraco.Core.Composing;
using Umbraco.Core.Logging;
using Umbraco.Core.Models;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;

namespace Ekom.Cache
{
    class DiscountCache : PerStoreCache<IDiscount>
    {
        public override string NodeAlias { get; } = "ekmOrderDiscount";

        /// <summary>
        /// ctor
        /// </summary>
        public DiscountCache(
            Configuration config,
            ILogger logger,
            IFactory factory,
            IBaseCache<IStore> storeCache,
            IPerStoreFactory<IDiscount> perStoreFactory,
            IUmbracoContextFactory context
        )
            : base(config, logger, factory, storeCache, perStoreFactory, context)
        {
        }

        /// <summary>
        /// Fill the given stores cache of TItem
        /// </summary>
        /// <param name="store">The current store being filled of TItem</param>
        /// <param name="results">Examine search results</param>
        /// <returns>Count of items added</returns>
        protected override int FillStoreCache(IStore store, List<IPublishedContent> results)
        {
            int count = 0;

            var curStoreCache
                = Cache[store.Alias] = new ConcurrentDictionary<Guid, IDiscount>();

            foreach (var r in results)
            {
                try
                {
                    // Traverse up parent nodes, checking disabled status and published status
                    if (!r.IsItemDisabled(store))
                    {
                        var item = _objFac?.Create(r, store) ?? new Discount(r, store);

                        count++;

                        curStoreCache[r.Key] = item;
                    }
                }
                catch (Exception ex)
                {
                    _logger.Error<DiscountCache>(
                        ex,
                        "Error on adding item with id: {Id} from Examine in Store: {Store}",
                        r.Id,
                        store.Alias
                    );
                }
            }

            return count;
        }

        /// <summary>
        /// Adds or replaces an item from all store caches
        /// </summary>
        public override void AddReplace(IContent node)
        {
            foreach (var store in _storeCache.Cache)
            {
                try
                {
                    if (!node.IsItemDisabled(store.Value))
                    {

                        var item = _objFac?.Create(node, store.Value)
                            ?? new Discount(node, store.Value);

                        Cache[store.Value.Alias][node.Key] = item;
                    }
                }
                catch (Exception ex) // Skip on fail
                {
                    _logger.Error<DiscountCache>(
                        ex,
                        "Error on Add/Replacing item with id: {Id} in store: {Store}",
                        node.Id,
                        store.Value.Alias
                    );
                }
            }
        }

        /// <summary>
        /// <see cref="ICache"/> implementation,
        /// handles removal of nodes when umbraco events fire
        /// </summary>
        public override void Remove(Guid key)
        {
            _logger.Debug<DiscountCache>("Attempting to remove discount with key {Key}", key);
            foreach (var store in _storeCache.Cache)
            {
                Cache[store.Value.Alias].TryRemove(key, out _);
            }
        }
    }
}
