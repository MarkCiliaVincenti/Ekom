#if NETFRAMEWORK
using System.Web.Http;
#else
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
#endif

using Ekom.Domain.Repositories;
using Ekom.Models;
using Ekom.Utilities;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Ekom.Exceptions;

namespace Ekom.Controllers
{
#pragma warning disable CA2007 // Consider calling ConfigureAwait on the awaited task
    /// <summary>
    /// Public api, used by property editors
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
    public class EkomApiController : ApiController
    {
        /// <summary>
        /// 
        /// </summary>
        public EkomApiController()
        {
            _config = Ekom.Configuration.Resolver.GetService<Configuration>();
            _countriesRepo = Ekom.Configuration.Resolver.GetService<CountriesRepository>();
        }
#else
    public class EkomApiController : ControllerBase
    {
        /// <summary>
        /// 
        /// </summary>
        public EkomApiController(Configuration config, CountriesRepository countriesRepo)
        {
            _config = config;
            _countriesRepo = countriesRepo;
        }

#endif        
            
        readonly CountriesRepository _countriesRepo;
        readonly Configuration _config;


        /// <summary>
        /// 
        /// </summary>
        public List<Country> GetCountries()
        {
            return _countriesRepo.GetAllCountries();
        }

        /// <summary>
        /// List of all stores
        /// </summary>
        /// <returns></returns>
        public IEnumerable<IStore> GetAllStores()
        {
            return API.Store.Instance.GetAllStores();
        }

        /// <summary>
        /// Repopulates all Ekom cache
        /// </summary>
        /// <returns></returns>
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
        public Configuration GetConfig()
        {
            return Ekom.Configuration.Instance;
        }


        /// <summary>
        /// Get Stock By Store
        /// </summary>
        /// <returns></returns>
        public int GetStockByStore(Guid id, string storeAlias)
        {
            return API.Stock.Instance.GetStock(id, storeAlias);
        }

        /// <summary>
        /// Get Stock 
        /// </summary>
        /// <returns></returns>
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
#pragma warning restore CA2007 // Consider calling ConfigureAwait on the awaited task
}
