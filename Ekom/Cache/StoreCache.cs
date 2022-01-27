using Ekom.Interfaces;
using Ekom.Models;
using Ekom.Utilities;
using Examine;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Umbraco.Core.Composing;
using Umbraco.Core.Logging;
using Umbraco.Core.Models;
using Umbraco.Examine;
using Umbraco.Web;

namespace Ekom.Cache
{
    class StoreCache : BaseCache<IStore>
    {
        public override string NodeAlias { get; } = "ekmStore";
        private readonly IUmbracoContextFactory _context;
        /// <summary>
        /// ctor
        /// </summary>
        public StoreCache(
            Configuration config,
            ILogger logger,
            IFactory factory,
            IObjectFactory<IStore> objectFactory,
            IUmbracoContextFactory context
        ) : base(config, logger, factory, objectFactory, context)
        {
            _context = context;
        }

        /// <summary>
        /// Fill Store cache with all products in examine
        /// </summary>
        public override void FillCache()
        {
            try
            {
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();

                _logger.Debug<StoreCache>("Starting to fill store cache...");
                int count = 0;

                using (var cref = _context.EnsureUmbracoContext())
                {
                    var cache = cref.UmbracoContext.Content;
                    var ekomRoot = cache.GetAtRoot().FirstOrDefault(x => x.IsDocumentType("ekom"));

                    if (ekomRoot == null)
                    {
                        throw new Exception("Ekom root node not found.");
                    }

                    var results = ekomRoot.DescendantsOfType(NodeAlias).ToList();


                    foreach (var r in results)
                    {
                        try
                        {
                            var item = _objFac?.Create(r) ?? new Store(r);

                            count++;

                            AddOrReplaceFromCache(r.Key, item);

                        }
                        catch (Exception ex) // Skip on fail
                        {
                            _logger.Warn<StoreCache>(ex, "Failed to map to store. Id: {Id}", r.Id);
                        }
                    }
                }

                stopwatch.Stop();
                _logger.Info<StoreCache>(
                    "Finished filling store cache with {Count} items. Time it took to fill: {Elapsed}",
                    count,
                    stopwatch.Elapsed);

            } catch(Exception ex)
            {
                _logger.Error<StoreCache>(ex, "Failed to build store Cache");
            }
            
        }

        /// <summary>
        /// <see cref="ICache"/> implementation.
        /// <see cref="StoreCache"/> specific implementation triggers refill of all <see cref="BaseCache{TItem}"/>
        /// </summary>
        public override void AddReplace(IContent node)
        {
            if (!node.IsItemUnpublished())
            {
                var item = (Store)(_objFac?.Create(node) ?? Activator.CreateInstance(typeof(Store), node));

                if (item != null)
                {
                    AddOrReplaceFromCache(node.Key, item);

                    IEnumerable<ICache> succeedingCaches = _config.Succeeding(this);

                    // Refill all per store caches
                    foreach (var cacheEntry in succeedingCaches)
                    {
                        if (cacheEntry is IPerStoreCache perStoreCache)
                        {
                            perStoreCache.FillCache(item);
                        }
                    }
                }
            }
        }
    }
}
