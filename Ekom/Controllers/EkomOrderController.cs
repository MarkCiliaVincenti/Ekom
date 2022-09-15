#if NETFRAMEWORK
using System.Web.Http;
using System.Web.Security.AntiXss;
#else
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
#endif
using Ekom.API;
using Ekom.Exceptions;
using Ekom.Models;
using Ekom.Utilities;
using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json;

namespace Ekom.Controllers
{

    /// <summary>
    /// Handles order/cart creation, updates and removals
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
    public partial class EkomOrderController : ApiController
    {
        /// <summary>
        /// ctor
        /// </summary>
        public EkomOrderController()
        {
            _logger = Ekom.Configuration.Resolver.GetService<ILogger<EkomOrderController>>();
        }
#else
    public partial class EkomOrderController : ControllerBase
    {
        /// <summary>
        /// ctor
        /// </summary>
        public EkomOrderController(ILogger<EkomOrderController> logger)
        {
            _logger = logger;
        }

#endif

        readonly ILogger _logger;

        /// <summary>
        /// Add product to order, also for updating or setting quantity of orderlines
        /// </summary>
        /// <param name="request">Guid Key of product</param>
        /// <returns></returns>
        public async Task<IOrderInfo> AddToOrder(OrderRequest request)
        {
            if (request == null)
            {
                return null;
            }

            try
            {
                //var variantIds = new List<Guid>();

                //if (request.variantId != null && request.variantId != Guid.Empty)
                //{
                //    variantIds.Add(request.variantId.Value);
                //}

                var orderInfo = await Order.Instance.AddOrderLineAsync(
                    request.productId,
                    request.quantity,
                    request.storeAlias,
                    new Ekom.API.AddOrderSettings
                    {
                        OrderAction = request.action ?? OrderAction.AddOrUpdate,
                        VariantKey = request.variantId,
                    });

                return orderInfo;
            }
            catch (Exception ex) when (!(ex is HttpResponseException))
            {
                var r = ExceptionHandler.Handle<HttpResponseException>(ex);
                if (r != null)
                {
                    throw r;
                }

                throw;
            }
        }

        ///// <summary>
        ///// Get order
        ///// </summary>
        ///// <returns></returns>
        //public ActionResult GetOrder()
        //{
        //    var order = Order.Instance.GetOrder();

        //    return Json(order, JsonRequestBehavior.AllowGet);
        //}

        /// <summary>
        /// Get order by store
        /// </summary>
        /// <returns></returns>
        public async Task<IOrderInfo> GetOrder(string storeAlias)
        {
            if (string.IsNullOrEmpty(storeAlias))
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            try
            {
                var order = await Order.Instance.GetOrderAsync(storeAlias);

                return order ?? throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            catch (Exception ex) when (!(ex is HttpResponseException))
            {
                var r = ExceptionHandler.Handle<HttpResponseException>(ex);
                if (r != null)
                {
                    throw r;
                }

                throw;
            }
        }

        ///// <summary>
        ///// Add product with multiple variants to order
        ///// </summary>
        ///// <param name="request">OrderMultipleRequest</param>
        ///// <returns></returns>
        //public JsonResult AddMultipleToOrder(OrderMultipleRequest request)
        //{
        //    try
        //    {
        //        var os = Order.Instance;

        //        _log.Info("Add To Multiple Order: " + request.productId);

        //        if (request.variant.Any())
        //        {
        //            IOrderInfo o = null;

        //            var variantIds = new List<Guid>();

        //            foreach (var variant in request.variant)
        //            {
        //                _log.Info("Add To Multiple Order: Variant: " + variant.Id + " - " + variant.Quantity);

        //                if (Guid.TryParse(variant.Id.ToString(), out Guid variantId))
        //                {
        //                    var items = new List<Guid>
        //                    {
        //                        variantId
        //                    };

        //                    o = os.AddOrderLine(request.productId, items, variant.Quantity, request.storeAlias, request.action);

        //                }
        //            }

        //            return Json(new
        //            {
        //                success = true,
        //                orderInfo = o
        //            });

        //        }

        //        return Json(new
        //        {
        //            success = false
        //        });

        //    }

        //    catch (Exception ex)
        //    {
        //        _log.Error("Add to multiple order Failed!", ex);

        //        return Json(new
        //        {
        //            success = false,
        //            error = ex.Message
        //        });
        //    }
        //}

        /// <summary>
        /// Update Customer Information to Order
        /// </summary>
        /// <param name="form">FormData</param>
        /// <returns></returns>
        public async Task<IOrderInfo> UpdateCustomerInformation()
        {
            try
            {
#if NETCOREAPP
                var form = Request.Form;
                var keys = form.Keys;
#else
                var form = await Request.Content.ReadAsFormDataAsync();
                var keys = form.AllKeys;
#endif

                var orderInfo = await Order.Instance.UpdateCustomerInformationAsync(
                    keys.ToDictionary(
                        k => k,
#if NETCOREAPP
                        v => System.Text.Encodings.Web.HtmlEncoder.Default.Encode(form[v])
#else
                        v => AntiXssEncoder.HtmlEncode(form.Get(v), false)
#endif
                ));

                return orderInfo;
            }
            catch (Exception ex) when (!(ex is HttpResponseException))
            {
                var r = ExceptionHandler.Handle<HttpResponseException>(ex);
                if (r != null)
                {
                    throw r;
                }

                throw;
            }
        }

        /// <summary>
        /// Update Shipping Information
        /// </summary>
        /// <returns></returns>
        public async Task<IOrderInfo> UpdateShippingProvider(Guid ShippingProvider, string storeAlias)
        {
            try
            {
                var orderInfo = await Order.Instance.UpdateShippingInformationAsync(ShippingProvider, storeAlias);

                return orderInfo;
            }
            catch (Exception ex) when (!(ex is HttpResponseException))
            {
                var r = ExceptionHandler.Handle<HttpResponseException>(ex);
                if (r != null)
                {
                    throw r;
                }

                throw;
            }
        }

        /// <summary>
        /// Update Payment Information
        /// </summary>
        /// <returns></returns>
        public async Task<IOrderInfo> UpdatePaymentProvider(Guid PaymentProvider, string storeAlias)
        {
            try
            {
                var orderInfo = await Order.Instance.UpdatePaymentInformationAsync(PaymentProvider, storeAlias);

                return orderInfo;
            }
            catch (Exception ex) when (!(ex is HttpResponseException))
            {
                var r = ExceptionHandler.Handle<HttpResponseException>(ex);
                if (r != null)
                {
                    throw r;
                }

                throw;
            }
        }

        /// <summary>
        /// Update order, change quantity of line in cart/order
        /// </summary>
        /// <param name="lineId">Guid Key of line to update</param>
        /// <param name="storeAlias"></param>
        /// <param name="quantity"></param>
        /// <returns></returns>
        [Obsolete("Deprecated, use AddToOrder and specify OrderAction")]
        public async Task<IOrderInfo> UpdateOrder(Guid lineId, string storeAlias, int quantity)
        {
            if (string.IsNullOrEmpty(storeAlias))
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            if (quantity == 0)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            try
            {
                var orderInfo = await Order.Instance.AddOrderLineAsync(
                    lineId,
                    quantity,
                    storeAlias);

                return orderInfo;
            }
            catch (Exception ex) when (!(ex is HttpResponseException))
            {
                var r = ExceptionHandler.Handle<HttpResponseException>(ex);
                if (r != null)
                {
                    throw r;
                }

                throw;
            }
        }

        /// <summary>
        /// Remove product from order/cart
        /// </summary>
        /// <param name="lineId">Guid Key of product/line</param>
        /// <param name="storeAlias"></param>
        /// <returns></returns>
        public async Task<IOrderInfo> RemoveOrderLine(Guid lineId, string storeAlias)
        {
            if (string.IsNullOrEmpty(storeAlias))
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            try
            {
                var orderInfo = await Order.Instance.RemoveOrderLineAsync(lineId, storeAlias);

                return orderInfo;
            }
            catch (Exception ex) when (!(ex is HttpResponseException))
            {
                var r = ExceptionHandler.Handle<HttpResponseException>(ex);
                if (r != null)
                {
                    throw r;
                }

                throw;
            }
        }

        /// <summary>
        /// Update currency for current store
        /// </summary>
        /// <param name="currency">Currency value</param>
        /// <returns></returns>
        public async Task<object> ChangeCurrency(string currency)
        {
            var store = API.Store.Instance.GetStore();

            var orderInfo = await Order.Instance.GetOrderAsync(store.Alias);

            if (orderInfo != null)
            {
                orderInfo = await Order.Instance.UpdateCurrencyAsync(currency, orderInfo.UniqueId, store.Alias).ConfigureAwait(false);
            }

#if NETFRAMEWORK
            var resp = new HttpResponseMessage
            {
                Content = new StringContent(
                    JsonConvert.SerializeObject(orderInfo), 
                    Encoding.UTF8, 
                    "application/json")
            };

            var cookie = new CookieHeaderValue("EkomCurrency-" + store.Alias, currency);
            cookie.Expires = DateTimeOffset.UtcNow.AddDays(360);

            resp.Headers.AddCookies(new CookieHeaderValue[] { cookie });

            return resp;
#else
            // ToDo: Verify this works correctly
            Response.Cookies.Append("EkomCurrency-" + store.Alias, currency, new Microsoft.AspNetCore.Http.CookieOptions
            {
                Expires = DateTime.UtcNow.AddDays(360),
            });

            return orderInfo;
#endif


        }
    }
}