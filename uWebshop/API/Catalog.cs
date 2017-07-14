﻿using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Umbraco.Core;
using uWebshop.Cache;
using uWebshop.Interfaces;
using uWebshop.Models;
using uWebshop.Services;

namespace uWebshop.API
{
    public class Catalog
    {
        private static readonly ILog Log =
                LogManager.GetLogger(
                    MethodBase.GetCurrentMethod().DeclaringType
                );
        public static Product GetProduct()
        {
            var appCache = ApplicationContext.Current.ApplicationCache;
            var r = appCache.RequestCache.GetCacheItem("uwbsRequest") as ContentRequest;

            return r?.Product;
        }

        public static Product GetProduct(Guid Id)
        {
            var appCache = ApplicationContext.Current.ApplicationCache;
            var r = appCache.RequestCache.GetCacheItem("uwbsRequest") as ContentRequest;

            if (r?.Store != null)
            {
                var product = GetProduct(r.Store.Alias, Id);

                return product;
            }

            return null;
        }

        public static Product GetProduct(string storeAlias, Guid Id)
        {
            var product = ProductCache.Cache[storeAlias].FirstOrDefault(x => x.Value.Key == Id).Value;

            return product;
        }

        public static Product GetProduct(int Id)
        {
            var appCache = ApplicationContext.Current.ApplicationCache;
            var r = appCache.RequestCache.GetCacheItem("uwbsRequest") as ContentRequest;

            if (r != null && r.Store != null)
            {
                var product = GetProduct(r.Store.Alias, Id);

                return product;
            }

            return null;
        }

        public static Product GetProduct(string storeAlias, int Id)
        {
            var product = ProductCache.Cache[storeAlias].FirstOrDefault(x => x.Value.Id == Id).Value;

            return product;
        }
        public static IEnumerable<Product> GetAllProducts()
        {
            var appCache = ApplicationContext.Current.ApplicationCache;
            var r = appCache.RequestCache.GetCacheItem("uwbsRequest") as ContentRequest;

            if (r != null && r.Store != null)
            {
                var products = GetAllProducts(r.Store.Alias);

                return products;
            }

            return null;
        }

        public static IEnumerable<Product> GetAllProducts(string storeAlias)
        {
            return ProductCache.Cache[storeAlias].Select(x => x.Value).OrderBy(x => x.SortOrder);
        }

        public static Category GetCategory()
        {
            var appCache = ApplicationContext.Current.ApplicationCache;
            var r = appCache.RequestCache.GetCacheItem("uwbsRequest") as ContentRequest;

            if (r != null && r.Category != null)
            {
                return r.Category;
            }

            return null;
        }

        public static Category GetCategory(int Id)
        {
            var store = StoreService.GetStoreFromCache();

            if (store != null)
            {
                var category = GetCategory(store.Alias, Id);

                return category;
            }

            return null;
        }

        public static Category GetCategory(string storeAlias, int Id)
        {
            return CategoryCache.Cache[storeAlias].FirstOrDefault(x => x.Value.Id == Id).Value;
        }

        public static IEnumerable<Category> GetRootCategories()
        {
            var store = StoreService.GetStoreFromCache();

            if (store != null)
            {
                var categories = GetRootCategories(store.Alias);

                return categories;
            }

            return null;
        }

        public static IEnumerable<Category> GetRootCategories(string storeAlias)
        {
            return CategoryCache.Cache[storeAlias]
                                .Where(x => x.Value.Level == 3)
                                .Select(x => x.Value)
                                .OrderBy(x => x.SortOrder);
        }

        public static Variant GetVariant(Guid Id)
        {
            var store = StoreService.GetStoreFromCache();

            if (store != null)
            {
                var variant = GetVariant(store.Alias, Id);

                return variant;
            }

            return null;
        }
        public static Variant GetVariant(string storeAlias, Guid Id)
        {
            var variant = VariantCache.Cache[storeAlias]
                                      .FirstOrDefault(x => x.Value.Key == Id)
                                      .Value;

            return variant;
        }
    }
}
