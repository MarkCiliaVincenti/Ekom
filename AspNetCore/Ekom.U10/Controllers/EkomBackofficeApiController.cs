using Ekom.Exceptions;
using Ekom.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System.Net;
using Umbraco.Cms.Core.Models;
using Umbraco.Cms.Core.PropertyEditors;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Web.BackOffice.Controllers;

namespace Ekom.U10.Controllers
{
    public class EkomBackofficeApiController : UmbracoAuthorizedApiController
    {
        private readonly IDataTypeService _dts;
        private readonly PropertyEditorCollection _propertyEditorCollection;
        private readonly ILocalizationService _localizationService;
        private readonly IMemberTypeService _memberTypeService;
        private readonly IContentTypeService _contentTypeService;

        readonly Configuration _config;

        public EkomBackofficeApiController(
            IDataTypeService dts,
            PropertyEditorCollection propertyEditorCollection,
            ILocalizationService localizationService,
            IMemberTypeService memberTypeService,
            IContentTypeService contentTypeService
            )
        {
            _dts = dts;
            _propertyEditorCollection = propertyEditorCollection;
            _localizationService = localizationService;
            _memberTypeService = memberTypeService;
            _contentTypeService = contentTypeService;
            _config = Configuration.Resolver.GetService<Configuration>();
        }

        public IEnumerable<object> GetNonEkomDataTypes()
        {
            return _dts.GetAll()
                .Where(x => !x.EditorAlias.StartsWith("Ekom"))
                .OrderBy(x => x.SortOrder)
                .Select(x => new
                {
                    guid = x.Key,
                    name = x.Name,
                    editorAlias = x.EditorAlias
                });
        }

        public object GetDataTypeById(Guid id)
        {
            var dtd = _dts.GetDataType(id);
            return FormatDataType(dtd);
        }

        public object GetDataTypeByAlias(
            string contentTypeAlias,
            string propertyAlias)
        {

            var ct = _contentTypeService.Get(contentTypeAlias);

            var prop = ct?.CompositionPropertyTypes.FirstOrDefault(x => x.Alias == propertyAlias);
            
            if (prop == null)
            {
                throw new Exceptions.HttpResponseException(HttpStatusCode.NotFound);
            }

            var dtd = _dts.GetDataType(prop.DataTypeKey);
            return FormatDataType(dtd);
        }

        public IEnumerable<object> GetLanguages()
        {
            var languages = _localizationService.GetAllLanguages();

            return languages;
        }

        public IEnumerable<object> GetStores()
        {
            var stores = API.Store.Instance.GetAllStores();

            return stores;
        }

        protected object FormatDataType(IDataType dtd)
        {
            if (dtd == null)
                throw new Exceptions.HttpResponseException(HttpStatusCode.NotFound);

            var propertyEditor = _propertyEditorCollection.FirstOrDefault(x => x.Alias == dtd.EditorAlias);

            var preValues = dtd.Configuration;

            return new
            {
                guid = dtd.Key,
                propertyEditorAlias = dtd.EditorAlias,
                preValues = preValues,
                view = propertyEditor.GetValueEditor(null).View
            };
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
            return Configuration.Instance;
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
}
