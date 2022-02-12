using Ekom.Core;
using Ekom.Core.Cache;
using Ekom.Core.Interfaces;
using Ekom.Core.Models;
using Examine;
using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Linq;
using Umbraco.Core;
using Umbraco.Core.Composing;
using Umbraco.Core.Logging;
using Umbraco.Core.Models;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Examine;
using Umbraco.Web;

namespace Ekom.U8.Cache.Base
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
        private readonly IUmbracoContextFactory _context;
        /// <summary>
        /// This is important since Caches are persistant objects while the ExamineManager should be per request scoped.
        /// </summary>
        protected IExamineManager ExamineManager => _factory.GetInstance<IExamineManager>();

        public BaseCache(
            Configuration config,
            ILogger logger,
            IFactory factory,
            IObjectFactory<TItem> objectFactory,
            IUmbracoContextFactory context
        )
        {
            _config = config;
            _logger = logger;
            _factory = factory;
            _objFac = objectFactory;
            _context = context;
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
            if (!string.IsNullOrEmpty(NodeAlias))
            {
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();

                _logger.Debug<BaseCache<TItem>>("Starting to fill...");

                var count = 0;

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
                            // Traverse up parent nodes, checking only published status
                            //if (!r.IsItemUnpublished())
                            //{
                            var item = (TItem)(_objFac?.Create(r) ?? Activator.CreateInstance(typeof(TItem), r));

                            if (item != null)
                            {
                                count++;

                                AddOrReplaceFromCache(r.Key, item);
                            }
                            //}
                        }
                        catch (Exception ex) // Skip on fail
                        {
                            _logger.Warn<BaseCache<TItem>>(ex, "Failed to map to store. Id: {Id}" + r.Id);
                        }
                    }
                }

                stopwatch.Stop();
                _logger.Info<BaseCache<TItem>>(
                    "Finished filling base cache with {Count} items. Time it took to fill: {Elapsed}", count, stopwatch.Elapsed);
            }
            else
            {
                _logger.Error<BaseCache<TItem>>(
                    "No examine search found with the name {ExamineIndex}, Can not fill cache.", _config.ExamineIndex);
            }
        }

        /// <summary>
        /// <see cref="ICache"/> implementation, <para/>
        /// handles addition of nodes when umbraco events fire
        /// </summary>
        public virtual void AddReplace(UmbracoContent content)
        {
            if (!content.IsItemUnpublished())
            {
                var item = (TItem)(_objFac?.Create(content) ?? Activator.CreateInstance(typeof(TItem), content));

                if (item != null) AddOrReplaceFromCache(content.Key, item);
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
