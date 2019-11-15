using Ekom.Interfaces;
using Ekom.Models;
using Ekom.Models.Discounts;
using Ekom.Utilities;
using System;
using System.Linq;
using Umbraco.Core.Composing;
using Umbraco.Core.Logging;
using Umbraco.Core.Models;
using Umbraco.Core.Services;

namespace Ekom.Cache
{
    class GlobalDiscountCache : PerStoreCache<IGlobalDiscount>
    {
        public override string NodeAlias { get; } = "ekmGlobalDiscount";

        readonly IContentService _contentService;
        readonly IPerStoreCache<IProduct> _perStoreProductCache;
        public GlobalDiscountCache(
            Configuration config,
            ILogger logger,
            IFactory factory,
            IBaseCache<IStore> storeCache,
            IPerStoreFactory<IGlobalDiscount> perStoreFactory,
            IContentService contentService,
            IPerStoreCache<IProduct> perStoreProductCache
        ) : base(config, logger, factory, storeCache, perStoreFactory)
        {
            _contentService = contentService;
            _perStoreProductCache = perStoreProductCache;
        }

        public override void AddReplace(IContent node)
        {
            // We use tempItem to only run the refresh on the products items once. and not for every store.
            IGlobalDiscount tempItem = null;

            foreach (var store in _storeCache.Cache)
            {
                try
                {
                    if (!node.IsItemDisabled(store.Value))
                    {
                        var item = _objFac?.Create(node, store.Value)
                            ?? (GlobalDiscount)Activator.CreateInstance(typeof(GlobalDiscount), node, store.Value);

                        if (item != null)
                        {
                            tempItem = item;

                            Cache[store.Value.Alias][node.Key] = item;
                        }
                    }
                }
                catch (Exception ex)
                {
                    _logger.Error<GlobalDiscountCache>(
                        ex,
                        $"Error on Add/Replacing item with id: {node.Id} in store: {store.Value.Alias}"
                    );
                }
            }

            RefreshProductCache(tempItem);
        }


        /// <summary>
        /// <see cref="ICache"/> implementation,
        /// handles removal of nodes when umbraco events fire
        /// </summary>
        public override void Remove(Guid key)
        {
            _logger.Debug<GlobalDiscountCache>($"Attempting to remove product discount with key {key}");
            IGlobalDiscount i = null;

            foreach (var store in _storeCache.Cache)
            {
                Cache[store.Value.Alias].TryRemove(key, out i);
            }

            RefreshProductCache(i);
        }

        private void RefreshProductCache(IGlobalDiscount discountItem)
        {
            if (discountItem != null)
            {
                // Refresh Product items cache
                foreach (var productId in discountItem.DiscountItems)
                {
                    //TODO We need to use something else then the IContent here. This will be very slow with many products
                    // Either that or compute Product.Price each time requested, should be fast with all the caching
                    var productNode = _contentService.GetById(productId);

                    if (productNode != null)
                    {
                        _perStoreProductCache.AddReplace(productNode);
                    }
                }
            }
        }
    }
}