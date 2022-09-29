using Ekom.Cache;
using Ekom.Models;
using Ekom.Services;
using Microsoft.Extensions.Logging;
using System.Configuration;
using Umbraco.Cms.Core.Cache;
using Umbraco.Cms.Core.Routing;
using Umbraco.Cms.Core.Web;
using Umbraco.Extensions;

namespace Ekom.U10
{
    class CatalogContentFinder : IContentFinder
    {
        readonly ILogger<CatalogContentFinder> _logger;
        readonly Configuration _config;
        readonly IStoreService _storeSvc;
        readonly IPerStoreCache<ICategory> _categoryCache;
        readonly IPerStoreCache<IProduct> _productCache;
        readonly AppCaches _appCaches;
        private readonly IUmbracoContextAccessor _umbracoContextAccessor;

        public CatalogContentFinder(
            ILogger<CatalogContentFinder> logger,
            Configuration config,
            IStoreService storeSvc,
            IPerStoreCache<ICategory> categoryCache,
            IPerStoreCache<IProduct> productCache,
            AppCaches appCaches,
            IUmbracoContextAccessor umbracoContextAccessor)
        {
            _logger = logger;
            _config = config;
            _storeSvc = storeSvc;
            _categoryCache = categoryCache;
            _productCache = productCache;
            _appCaches = appCaches;
            _umbracoContextAccessor = umbracoContextAccessor;
        }


        public Task<bool> TryFindContent(IPublishedRequestBuilder contentRequest)
        {
            var path = contentRequest.Uri.GetAbsolutePathDecoded();
            if (path.StartsWith("/umbraco") is false)
            {
                return Task.FromResult(false); // Not found
            }

            if (!_umbracoContextAccessor.TryGetUmbracoContext(out var umbracoContext))
            {
                return Task.FromResult(false);
            }
            
            // Have we got a node with ID
            var content = umbracoContext.Content.GetById(contentRequest.PublishedContent.Id);
            if (content is null)
            {
                // If not found, let another IContentFinder in the collection try.
                return Task.FromResult(false);
            }

            // If content is found, then render that node
            contentRequest.SetPublishedContent(content);
            return Task.FromResult(true);
        }
        /// <summary>
        /// Maps virtual URLs to IPublishedContent items
        /// Performs various request related processing
        /// F.x. determining the Store/Currency first from Cookie, then domain and then default
        /// </summary>
        /*public bool TryFindContent(PublishedRequest contentRequest)
        {
            try
            {
                var umbracoContext = contentRequest.UmbracoContext;
                var httpContext = umbracoContext.HttpContext;
                var umbHelper = Current.UmbracoHelper;
                // Allows for configuration of content nodes to use for matching all requests
                // Use case: Ekom populated by adapter, used as in memory cache with no backing umbraco nodes
                var virtualContent = ConfigurationManager.AppSettings["Ekom.VirtualContent"];

                var path = contentRequest.Uri
                                         .AbsolutePath
                                         .ToLower()
                                         .AddTrailing();

                if (contentRequest.Uri.AbsolutePath.StartsWith("/umbraco"))
                {
                    return false;
                }

                var store = _storeSvc.GetStoreByDomain(contentRequest.Domain?.Name, contentRequest.Culture.Name);

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
                    contentId = virtualContent.InvariantEquals("true") ? int.Parse(umbHelper.GetDictionaryValue("virtualProductNode")) : product.Id;

                    var urlArray = path.Split('/');
                    var categoryUrlArray = urlArray.Take(urlArray.Length - 2);
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
                        contentId = virtualContent.InvariantEquals("true")
                            ? int.Parse(umbHelper.GetDictionaryValue("virtualCategoryNode"))
                            : category.Id;
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
                _logger.LogError(ex, "Error trying to find matching content for request");
            }

            return false;
        }*/
    }
}
