using Ekom.Cache;
using Ekom.Interfaces;
using Ekom.Models;
using Ekom.Services;
using Ekom.Utilities;
using System;
using System.Configuration;
using System.Linq;
using Umbraco.Core;
using Umbraco.Core.Cache;
using Umbraco.Core.Composing;
using Umbraco.Core.Logging;
using Umbraco.Web;
using Umbraco.Web.Routing;
using Umbraco.Web.Security;

namespace Ekom
{
    class CatalogContentFinder : IContentFinder
    {
        ILogger _logger;
        Configuration _config;
        StoreService _storeSvc;
        IPerStoreCache<ICategory> _categoryCache;
        IPerStoreCache<IProduct> _productCache;
        AppCaches _appCaches;
        UmbracoHelper _umbHelper;

        public CatalogContentFinder(
            ILogger logger,
            Configuration config,
            StoreService storeSvc,
            IPerStoreCache<ICategory> categoryCache,
            IPerStoreCache<IProduct> productCache,
            AppCaches appCaches,
            UmbracoHelper umbHelper)
        {
            _logger = logger;
            _config = config;
            _storeSvc = storeSvc;
            _categoryCache = categoryCache;
            _productCache = productCache;
            _appCaches = appCaches;
            _umbHelper = umbHelper;
        }

        /// <summary>
        /// Maps virtual URLs to IPublishedContent items
        /// Performs various request related processing
        /// F.x. determining the Store/Currency first from Cookie, then domain and then default
        /// </summary>
        public bool TryFindContent(PublishedRequest contentRequest)
        {
            try
            {
                var umbracoContext = contentRequest.UmbracoContext;
                var httpContext = umbracoContext.HttpContext;

                // Allows for configuration of content nodes to use for matching all requests
                // Use case: Ekom populated by adapter, used as in memory cache with no backing umbraco nodes
                var virtualContent = ConfigurationManager.AppSettings["Ekom.VirtualContent"];

                var path = contentRequest.Uri
                                         .AbsolutePath
                                         .ToLower()
                                         .AddTrailing();

                if (httpContext.Request.Path.StartsWith("/umbraco"))
                {
                    return false;
                }

                var store = _storeSvc.GetStoreByDomain(contentRequest.Domain.Name);

                if (store == null)
                {
                    throw new Exception("No store found.");
                }

                #region Product and/or Category

                // Requesting Product?
                var product = _productCache.Cache[store.Alias]
                                          .FirstOrDefault(x => x.Value.Urls != null &&
                                                               x.Value.Urls.Contains(path))
                                          .Value;

                var contentId = 0;
                ICategory category;

                if (product != null && !string.IsNullOrEmpty(product.Slug))
                {
                    contentId = virtualContent.InvariantEquals("true") ? int.Parse(_umbHelper.GetDictionaryValue("virtualProductNode")) : product.Id;

                    var urlArray = path.Split('/');
                    var categoryUrlArray = urlArray.Take(urlArray.Count() - 2);
                    var categoryUrl = string.Join("/", categoryUrlArray).AddTrailing();

                    category = _categoryCache.Cache[store.Alias]
                                            .FirstOrDefault(x => x.Value.Urls.Contains(categoryUrl))
                                            .Value;
                }
                else // Request Category?
                {
                    category = _categoryCache.Cache[store.Alias]
                                            .FirstOrDefault(x => x.Value.Urls != null &&
                                                                 x.Value.Urls.Contains(path))
                                            .Value;

                    if (category != null && !string.IsNullOrEmpty(category.Slug))
                    {
                        contentId = virtualContent.InvariantEquals("true") ? int.Parse(_umbHelper.GetDictionaryValue("virtualCategoryNode")) : category.Id;
                    }
                    // else Requesting Neither
                }
                #endregion

                if (_appCaches.RequestCache.Get("ekmRequest") is ContentRequest ekmRequest)
                {
                    ekmRequest.Store = store;
                    ekmRequest.Product = product;
                    ekmRequest.Category = category;
                }

                // Request for Product or Category
                if (contentId != 0)
                {
                    var contentCache = umbracoContext.Content;

                    var content = contentCache.GetById(contentId);

                    if (content != null)
                    {
                        contentRequest.PublishedContent = content;

                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.Error<CatalogContentFinder>(ex, "Error trying to find matching content for request");
            }

            return false;
        }
    }
}
