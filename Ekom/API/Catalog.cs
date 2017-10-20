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
        ApplicationContext _appCtx;
        ICacheProvider _reqCache => _appCtx.ApplicationCache.RequestCache;

        IPerStoreCache<Product> _productCache;
        IPerStoreCache<Category> _categoryCache;
        IPerStoreCache<Variant> _variantCache;
        IStoreService _storeSvc;
        Configuration _config;

        /// <summary>
        /// ctor
        /// </summary>
        public Catalog(
            ApplicationContext appCtx,
            IPerStoreCache<Product> productCache,
            IPerStoreCache<Category> categoryCache,
            IPerStoreCache<Variant> variantCache,
            IStoreService storeSvc,
            Configuration config,
            ILogFactory logFac
        )
        {
            _appCtx = appCtx;
            _productCache = productCache;
            _categoryCache = categoryCache;
            _variantCache = variantCache;
            _storeSvc = storeSvc;
            _config = config;

            _log = logFac.GetLogger(typeof(Catalog));
        }

        /// <summary>
        /// Get current product using data from the uwbsRequest <see cref="ContentRequest"/> object
        /// </summary>
        /// <returns></returns>
        public Product GetProduct()
        {
            var r = _reqCache.GetCacheItem("uwbsRequest") as ContentRequest;

            return r?.Product;
        }

        /// <summary>
        /// Get product by Guid
        /// </summary>
        /// <returns></returns>
        public Product GetProduct(Guid Id)
        {
            var r = _reqCache.GetCacheItem("uwbsRequest") as ContentRequest;

            if (r?.Store != null)
            {
                var product = GetProduct(r.Store.Alias, Id);

                return product;
            }

            return null;
        }

        public Product GetProduct(string storeAlias, Guid Id)
        {
            return _productCache.Cache[storeAlias][Id];
        }

        public Product GetProduct(int Id)
        {
            if (_reqCache.GetCacheItem("uwbsRequest") is ContentRequest r && r.Store != null)
            {
                var product = GetProduct(r.Store.Alias, Id);

                return product;
            }

            return null;
        }

        public Product GetProduct(string storeAlias, int Id)
        {
            return _productCache.Cache[storeAlias].FirstOrDefault(x => x.Value.Id == Id).Value;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            if (_reqCache.GetCacheItem("uwbsRequest") is ContentRequest r && r.Store != null)
            {
                var products = GetAllProducts(r.Store.Alias);

                return products;
            }

            return null;
        }

        public IEnumerable<Product> GetAllProducts(string storeAlias)
        {
            return _productCache.Cache[storeAlias].Select(x => x.Value).OrderBy(x => x.SortOrder);
        }

        public IEnumerable<Product> GetProductsByIds(int[] productIds)
        {
            if (_reqCache.GetCacheItem("uwbsRequest") is ContentRequest r && r.Store != null)
            {
                var products = GetProductsByIds(productIds, r.Store.Alias);

                return products;
            }

            return null;
        }

        public IEnumerable<Product> GetProductsByIds(int[] productIds, string storeAlias)
        {
            return _productCache.Cache[storeAlias].Where(x => productIds.Contains(x.Value.Id)).Select(x => x.Value).OrderBy(x => x.SortOrder);
        }

        public Category GetCategory()
        {
            if (_reqCache.GetCacheItem("uwbsRequest") is ContentRequest r && r.Category != null)
            {
                return r.Category;
            }

            return null;
        }

        public Category GetCategory(int Id)
        {
            var store = _storeSvc.GetStoreFromCache();

            if (store != null)
            {
                var category = GetCategory(store.Alias, Id);

                return category;
            }

            return null;
        }

        public Category GetCategory(string storeAlias, int Id)
        {
            return _categoryCache.Cache[storeAlias].FirstOrDefault(x => x.Value.Id == Id).Value;
        }

        public IEnumerable<Category> GetRootCategories()
        {
            var store = _storeSvc.GetStoreFromCache();

            if (store != null)
            {
                var categories = GetRootCategories(store.Alias);

                return categories;
            }

            return null;
        }

        public IEnumerable<Category> GetRootCategories(string storeAlias)
        {
            return _categoryCache.Cache[storeAlias]
                                .Where(x => x.Value.Level == _config.CategoryRootLevel)
                                .Select(x => x.Value)
                                .OrderBy(x => x.SortOrder);
        }

        public IEnumerable<Category> GetAllCategories()
        {
            var store = _storeSvc.GetStoreFromCache();

            if (store != null)
            {
                var categories = GetAllCategories(store.Alias);

                return categories;
            }

            return null;
        }

        public IEnumerable<Category> GetAllCategories(string storeAlias)
        {
            return _categoryCache.Cache[storeAlias]
                                .Select(x => x.Value)
                                .OrderBy(x => x.SortOrder);
        }

        public Variant GetVariant(Guid Id)
        {
            var store = _storeSvc.GetStoreFromCache();

            if (store != null)
            {
                var variant = GetVariant(store.Alias, Id);

                return variant;
            }

            return null;
        }

        public Variant GetVariant(string storeAlias, Guid Id)
        {
            return _variantCache.Cache[storeAlias][Id];
        }
    }
}
