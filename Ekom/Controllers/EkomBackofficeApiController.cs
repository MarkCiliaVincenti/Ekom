#if NETFRAMEWORK
using System.Web.Http;
#else
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
#endif
using Ekom.Domain.Repositories;
using Ekom.Exceptions;
using Ekom.Utilities;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Ekom.Services;
using Ekom.Authorization;

namespace Ekom.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage(
        "Reliability",
        "CA2007:Consider calling ConfigureAwait on the awaited task",
        Justification = "Async controller actions don't need ConfigureAwait")]
    [System.Diagnostics.CodeAnalysis.SuppressMessage(
        "Style",
        "VSTHRD200:Use \"Async\" suffix for async methods",
        Justification = "Async controller action")]
#if NETFRAMEWORK

    public class EkomBackofficeApiController : ApiController
    {
        /// <summary>
        /// 
        /// </summary>
        public EkomBackofficeApiController(Configuration config, IUmbracoService umbracoService)
        {
        }
#else
    [Route("/api/[controller]/[action]")]
    public class EkomBackofficeApiController : ControllerBase
    {
        /// <summary>
        /// 
        /// </summary>
        public EkomBackofficeApiController(Configuration config, IUmbracoService umbracoService)
        {
            _config = config;
            _umbracoService = umbracoService;
        }
#endif

        readonly Configuration _config;
        readonly IUmbracoService _umbracoService;

        [UmbracoUserAuthorize]
        public IEnumerable<object> GetNonEkomDataTypes()
            => _umbracoService.GetNonEkomDataTypes();

        [UmbracoUserAuthorize]
        public object GetDataTypeById(Guid id)
            => _umbracoService.GetDataTypeById(id);

        [UmbracoUserAuthorize]
        public object GetDataTypeByAlias(
            string contentTypeAlias,
            string propertyAlias)
            => _umbracoService.GetDataTypeByAlias(contentTypeAlias, propertyAlias);

        [UmbracoUserAuthorize]
        public IEnumerable<object> GetLanguages()
            => _umbracoService.GetLanguages();

        [UmbracoUserAuthorize]
        public IEnumerable<object> GetStores()
        {
            var stores = API.Store.Instance.GetAllStores();

            return stores;
        }

        /// <summary>
        /// Repopulates all Ekom cache
        /// </summary>
        /// <returns></returns>
        [UmbracoUserAuthorize]
        public bool PopulateCache()
        {
            foreach (var cacheEntry in _config.CacheList.Value)
            {
                cacheEntry.FillCache();
            }

            return true;
        }

        /// <summary>
        /// Get Config
        /// </summary>
        [UmbracoUserAuthorize]
        public Configuration GetConfig()
        {
            return _config;
        }

        /// <summary>
        /// Get Stock By Store
        /// </summary>
        /// <returns></returns>
        [UmbracoUserAuthorize]
        public int GetStockByStore(Guid id, string storeAlias)
        {
            return API.Stock.Instance.GetStock(id, storeAlias);
        }

        /// <summary>
        /// Get Stock 
        /// </summary>
        /// <returns></returns>
        [UmbracoUserAuthorize]
        public int GetStock(Guid id)
        {
            return API.Stock.Instance.GetStock(id);
        }

        /// <summary>
        /// Increment stock count of item. 
        /// If PerStoreStock is configured, gets store from cache and updates relevant item.
        /// If no stock entry exists, creates a new one, then attempts to update.
        /// </summary>
        [HttpPost]
        [UmbracoUserAuthorize]
        public async Task<HttpResponseException> IncrementStock(Guid id, int stock)
        {
            try
            {
                await API.Stock.Instance.IncrementStockAsync(id, stock);

                // ToDo: Log Umbraco user performing the action
                //Logger.Info<ApiController>("")

                throw new HttpResponseException(HttpStatusCode.OK);
            }
            catch (Exception ex) when (!(ex is HttpResponseException))
            {
                throw ExceptionHandler.Handle<HttpResponseException>(ex);
            }
        }

        /// <summary>
        /// Increment stock count of store item. 
        /// If no stock entry exists, creates a new one, then attempts to update.
        /// </summary>
        [HttpPost]
        [UmbracoUserAuthorize]
        public async Task IncrementStock(Guid id, string storeAlias, int stock)
        {
            try
            {
                await API.Stock.Instance.IncrementStockAsync(id, storeAlias, stock);

                // ToDo: Log Umbraco user performing the action

                throw new HttpResponseException(HttpStatusCode.OK);
            }
            catch (Exception ex) when (!(ex is HttpResponseException))
            {
                throw ExceptionHandler.Handle<HttpResponseException>(ex);
            }
        }

        /// <summary>
        /// Sets stock count of item. 
        /// If PerStoreStock is configured, gets store from cache and updates relevant item.
        /// If no stock entry exists, creates a new one, then attempts to update.
        /// </summary>
        [HttpPost]
        [UmbracoUserAuthorize]
        public async Task SetStock(Guid id, int stock)
        {
            try
            {
                await API.Stock.Instance.SetStockAsync(id, stock);

                // ToDo: Log Umbraco user performing the action

                throw new HttpResponseException(HttpStatusCode.OK);
            }
            catch (Exception ex) when (!(ex is HttpResponseException))
            {
                throw ExceptionHandler.Handle<HttpResponseException>(ex);
            }
        }

        /// <summary>
        /// Sets stock count of store item. 
        /// If no stock entry exists, creates a new one, then attempts to update.
        /// </summary>
        [HttpPost]
        [UmbracoUserAuthorize]
        public async Task SetStock(Guid id, string storeAlias, int stock)
        {
            try
            {
                await API.Stock.Instance.SetStockAsync(id, storeAlias, stock);

                // ToDo: Log Umbraco user performing the action

                throw new HttpResponseException(HttpStatusCode.OK);
            }
            catch (Exception ex) when (!(ex is HttpResponseException))
            {
                throw ExceptionHandler.Handle<HttpResponseException>(ex);
            }
        }

        /// <summary>
        /// Insert Coupon
        /// </summary>
        [HttpPost]
        [UmbracoUserAuthorize]
        public async Task InsertCoupon(string couponCode, int numberAvailable, Guid discountId)
        {
            try
            {
                await API.Order.Instance.InsertCouponCodeAsync(couponCode, numberAvailable, discountId);

                throw new HttpResponseException(HttpStatusCode.OK);
            }
            catch (Exception ex) when (!(ex is HttpResponseException))
            {
                throw ExceptionHandler.Handle<HttpResponseException>(ex);
            }
        }

        /// <summary>
        /// Remove Coupon
        /// </summary>
        [HttpPost]
        [UmbracoUserAuthorize]
        public async Task RemoveCoupon(string couponCode, Guid discountId)
        {
            try
            {
                await API.Order.Instance.RemoveCouponCodeAsync(couponCode, discountId);

                throw new HttpResponseException(HttpStatusCode.OK);
            }
            catch (Exception ex) when (!(ex is HttpResponseException))
            {
                throw ExceptionHandler.Handle<HttpResponseException>(ex);
            }
        }

        /// <summary>
        /// Get Coupons for Discount
        /// </summary>
        [HttpPost]
        [UmbracoUserAuthorize]
        public async Task<object> GetCouponsForDiscount(Guid discountId)
        {
            try
            {
                var items = await API.Order.Instance.GetCouponsForDiscountAsync(discountId);

                return items;
            }
            catch (Exception ex)
            {
                throw ExceptionHandler.Handle<HttpResponseException>(ex);
            }
        }
    }
}