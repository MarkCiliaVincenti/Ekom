using Ekom.Interfaces;
using Ekom.Models.Data;
using Ekom.Utilities;
using Examine;
using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using Umbraco.Core;
using Umbraco.Core.Composing;
using Umbraco.Core.Logging;
using Umbraco.Core.Models;
using Umbraco.Examine;

namespace Ekom.Cache
{
    /// <summary>
    /// For custom caches or global non store dependant caches
    /// </summary>
    /// <typeparam name="TItem">Type of data to cache</typeparam>
    abstract class BaseCache<TItem> : ICache, IBaseCache<TItem>
        where TItem : class
    {
        protected Configuration _config;
        protected ILogger _logger;
        protected IObjectFactory<TItem> _objFac;
        protected IFactory _factory;

        /// <summary>
        /// This is important since Caches are persistant objects while the ExamineManager should be per request scoped.
        /// </summary>
        protected IExamineManager ExamineManager => _factory.GetInstance<IExamineManager>();

        public BaseCache(
            Configuration config,
            ILogger logger,
            IFactory factory,
            IObjectFactory<TItem> objectFactory
        )
        {
            _config = config;
            _logger = logger;
            _factory = factory;
            _objFac = objectFactory;
        }

        /// <summary>
        /// Umbraco Node Alias name used in Examine search
        /// </summary>
        public abstract string NodeAlias { get; }

        public virtual ConcurrentDictionary<Guid, TItem> Cache { get; }
         = new ConcurrentDictionary<Guid, TItem>();

        /// <summary>
        /// Class indexer
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public TItem this[Guid index]
        {
            get => Cache[index];
            set => Cache[index] = value;
        }

        protected void AddOrReplaceFromCache(Guid id, TItem newCacheItem)
        {
            Cache[id] = newCacheItem;
        }

        protected void RemoveItemFromCache(Guid id)
        {
            Cache.TryRemove(id, out TItem i);
        }

        /// <summary>
        /// Base FillCache method appropriate for most derived caches
        /// </summary>
        public virtual void FillCache()
        {
            if (!string.IsNullOrEmpty(NodeAlias) 
            && ExamineManager.TryGetSearcher(_config.ExamineSearcher, out ISearcher searcher))
            {
#if DEBUG
                Stopwatch stopwatch = new Stopwatch();

                stopwatch.Start();
#endif
                _logger.Debug<BaseCache<TItem>>("Starting to fill...");

                var count = 0;

                var results = searcher.CreateQuery("content")
                    .NodeTypeAlias(NodeAlias)
                    .Execute();

                foreach (var r in results)
                {
                    try
                    {
                        // Traverse up parent nodes, checking only published status
                        if (!r.IsItemUnpublished())
                        {
                            var item = (TItem)(_objFac?.Create(r) ?? Activator.CreateInstance(typeof(TItem), r));

                            if (item != null)
                            {
                                count++;

                                var itemKey = Guid.Parse(r.Key());
                                AddOrReplaceFromCache(itemKey, item);
                            }
                        }
                    }
                    catch (Exception ex) // Skip on fail
                    {
                        _logger.Warn<BaseCache<TItem>>("Failed to map to store. Id: " + r.Id, ex);
                    }
                }

#if DEBUG
                stopwatch.Stop();
                _logger.Debug<BaseCache<TItem>>(
                    $"Finished filling base cache with {count} items. Time it took to fill: {stopwatch.Elapsed}");
#endif
#if !DEBUG
                _logger.Debug(typeof(BaseCache<TItem>), "Finished filling base cache with " + count + " items);
#endif
            }
            else
            {
                _logger.Error<BaseCache<TItem>>(
                    $"No examine search found with the name {_config.ExamineSearcher}, Can not fill cache.");
            }
        }

        /// <summary>
        /// <see cref="ICache"/> implementation, <para/>
        /// handles addition of nodes when umbraco events fire
        /// </summary>
        public virtual void AddReplace(IContent node)
        {
            if (!node.IsItemUnpublished())
            {
                var item = (TItem)(_objFac?.Create(node) ?? Activator.CreateInstance(typeof(TItem), node));

                if (item != null) AddOrReplaceFromCache(node.Key, item);
            }
        }

        /// <summary>
        /// <see cref="ICache"/> implementation, <para/>
        /// handles removal of nodes when umbraco events fire
        /// </summary>
        public virtual void Remove(Guid id)
        {
            RemoveItemFromCache(id);
        }
    }
}
