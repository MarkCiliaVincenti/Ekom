﻿using Ekom.Cache;
using Ekom.Interfaces;
using Ekom.Models;
using Ekom.Services;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using Umbraco.Core;
using Umbraco.Core.Cache;

namespace Ekom.API
{
    /// <summary>
    /// The Ekom API, grants access to the current product/category/variant 
    /// and various other depending on your current routed context.
    /// </summary>
    public class Catalog
    {
        private static Catalog _current;
        /// <summary>
        /// Catalog Singleton
        /// </summary>
        public static Catalog Current
        {
            get
            {
                return _current ?? (_current = Configuration.container.GetInstance<Catalog>());
            }
        }

        ILog _log;
        Configuration _config;
        ApplicationContext _appCtx;
        ICacheProvider _reqCache => _appCtx.ApplicationCache.RequestCache;
        IStoreService _storeSvc => Configuration.container.GetInstance<IStoreService>();

        IPerStoreCache<IProduct> _productCache;
        IPerStoreCache<ICategory> _categoryCache;
        IPerStoreCache<IVariant> _variantCache;

        /// <summary>
        /// ctor
        /// </summary>
        internal Catalog(
            ApplicationContext appCtx,
            Configuration config,
            ILogFactory logFac,
            IPerStoreCache<IProduct> productCache,
            IPerStoreCache<ICategory> categoryCache,
            IPerStoreCache<IVariant> variantCache
        )
        {
            _appCtx = appCtx;
            _config = config;
            _productCache = productCache;
            _categoryCache = categoryCache;
            _variantCache = variantCache;

            _log = logFac.GetLogger<Catalog>();
        }

        /// <summary>
        /// Get current product using data from the ekmRequest <see cref="ContentRequest"/> object
        /// </summary>
        /// <returns></returns>
        public IProduct GetProduct()
        {
            var r = _reqCache.GetCacheItem("ekmRequest") as ContentRequest;

            return r?.Product;
        }

        /// <summary>
        /// Get product by Guid
        /// </summary>
        /// <returns></returns>
        public IProduct GetProduct(Guid Key)
        {
            var r = _reqCache.GetCacheItem("ekmRequest") as ContentRequest;

            if (r?.Store != null)
            {
                var product = GetProduct(r.Store.Alias, Key);

                return product;
            }

            return null;
        }

        public IProduct GetProduct(string storeAlias, Guid Id)
        {
            return _productCache.Cache[storeAlias][Id];
        }

        public IProduct GetProduct(int Id)
        {
            if (_reqCache.GetCacheItem("ekmRequest") is ContentRequest r && r.Store != null)
            {
                var product = GetProduct(r.Store.Alias, Id);

                return product;
            }

            return null;
        }

        public IProduct GetProduct(string storeAlias, int Id)
        {
            return _productCache.Cache[storeAlias].FirstOrDefault(x => x.Value.Id == Id).Value;
        }

        public IEnumerable<IProduct> GetAllProducts()
        {
            if (_reqCache.GetCacheItem("ekmRequest") is ContentRequest r && r.Store != null)
            {
                var products = GetAllProducts(r.Store.Alias);

                return products;
            }

            return null;
        }

        public IEnumerable<IProduct> GetAllProducts(string storeAlias)
        {
            return _productCache.Cache[storeAlias].Select(x => x.Value).OrderBy(x => x.SortOrder);
        }

        public IEnumerable<IProduct> GetProductsByIds(int[] productIds)
        {
            if (_reqCache.GetCacheItem("ekmRequest") is ContentRequest r && r.Store != null)
            {
                var products = GetProductsByIds(productIds, r.Store.Alias);

                return products;
            }

            return null;
        }

        public IEnumerable<IProduct> GetProductsByIds(int[] productIds, string storeAlias)
        {
            return _productCache.Cache[storeAlias].Where(x => productIds.Contains(x.Value.Id)).Select(x => x.Value).OrderBy(x => x.SortOrder);
        }

        /// <summary>
        /// Get category from ekmRequest
        /// </summary>
        /// <returns></returns>
        public ICategory GetCategory()
        {
            if (_reqCache.GetCacheItem("ekmRequest") is ContentRequest r)
            {
                return r?.Category;
            }

            return null;
        }

        public ICategory GetCategory(int Id)
        {
            var store = _storeSvc.GetStoreFromCache();

            if (store != null)
            {
                var category = GetCategory(store.Alias, Id);

                return category;
            }

            return null;
        }

        public ICategory GetCategory(string storeAlias, int Id)
        {
            return _categoryCache.Cache[storeAlias].FirstOrDefault(x => x.Value.Id == Id).Value;
        }

        public IEnumerable<ICategory> GetRootCategories()
        {
            var store = _storeSvc.GetStoreFromCache();

            if (store != null)
            {
                var categories = GetRootCategories(store.Alias);

                return categories;
            }

            return null;
        }

        public IEnumerable<ICategory> GetRootCategories(string storeAlias)
        {
            return _categoryCache.Cache[storeAlias]
                .Where(x => x.Value.Level == _config.CategoryRootLevel)
                .Select(x => x.Value)
                .OrderBy(x => x.SortOrder);
        }

        public IEnumerable<ICategory> GetAllCategories()
        {
            var store = _storeSvc.GetStoreFromCache();

            if (store != null)
            {
                var categories = GetAllCategories(store.Alias);

                return categories;
            }

            return null;
        }

        public IEnumerable<ICategory> GetAllCategories(string storeAlias)
        {
            return _categoryCache.Cache[storeAlias]
                                .Select(x => x.Value)
                                .OrderBy(x => x.SortOrder);
        }

        public IVariant GetVariant(Guid Id)
        {
            var store = _storeSvc.GetStoreFromCache();

            if (store != null)
            {
                var variant = GetVariant(store.Alias, Id);

                return variant;
            }

            return null;
        }

        public IVariant GetVariant(string storeAlias, Guid Key)
        {
            if (_variantCache.Cache[storeAlias].TryGetValue(Key, out var val))
            {
                return val;
            }

            return null;
        }

        public IEnumerable<IVariant> GetVariantsByGroup(string storeAlias, int Id)
        {
            return _variantCache.Cache[storeAlias]
                                   .Where(x => x.Value.VariantGroup.Id == Id)
                                   .Select(x => x.Value);
        }
    }
}
