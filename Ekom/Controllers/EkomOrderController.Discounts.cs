#if NETFRAMEWORK
using System.Web.Http;
using System.Web.Security.AntiXss;
#else
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
#endif
using Ekom.API;
using Ekom.Exceptions;
using Ekom.Utilities;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Ekom.Controllers
{
    /// <summary>
    /// Handles order/cart creation, updates and removals
    /// </summary>
#if NETFRAMEWORK
    public partial class EkomOrderController : ApiController
    {
#else
    public partial class EkomOrderController : ControllerBase
    {
#endif
        /// <summary>
        /// Http status code custom response
        /// </summary>
        public const int NoChangeResponse = 450;

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task ApplyCouponToOrder(string coupon, string storeAlias)
        {
            try
            {
                if (string.IsNullOrEmpty(coupon))
                {
                    throw new HttpResponseException(400, "Coupon code can not be empty");
                }

                if (await Order.Instance.ApplyCouponToOrderAsync(coupon, storeAlias))
                {
                    throw new HttpResponseException(HttpStatusCode.OK);
                }
                else
                {
                    throw new HttpResponseException(NoChangeResponse, "Discount not modified, better discount found");
                }
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
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult> RemoveCouponFromOrder(string storeAlias)
        {
            try
            {
                await Order.Instance.RemoveCouponFromOrderAsync(storeAlias);
                throw new HttpResponseException(HttpStatusCode.OK);
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
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult> ApplyCouponToOrderLine(Guid productKey, string coupon, string storeAlias)
        {
            try
            {
                if (await Order.Instance.ApplyCouponToOrderLineAsync(productKey, coupon, storeAlias))
                {
                    throw new HttpResponseException(HttpStatusCode.OK);
                }
                else
                {
                    throw new HttpResponseException(NoChangeResponse, "Discount not modified, better discount found");
                }
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
        /// 
        /// </summary>
        /// <exception cref="OrderLineNotFoundException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public async Task<ActionResult> RemoveCouponFromOrderLine(Guid productKey, string storeAlias)
        {
            try
            {
                await Order.Instance.RemoveCouponFromOrderLineAsync(productKey, storeAlias);
                throw new HttpResponseException(HttpStatusCode.OK);
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
    }
#pragma warning restore CA2007 // Consider calling ConfigureAwait on the awaited task
}
