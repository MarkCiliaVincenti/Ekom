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
using System.Net.Http;

namespace Ekom.Controllers
{
    /// <summary>
    /// Handles order/cart creation, updates and removals
    /// </summary>
#if NETFRAMEWORK
    public partial class EkomOrderController : ApiController
    {
#else
    [Route("ekom/order/discounts")]
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
        [HttpPost]
        [Route("coupon/{coupon}/storealias/{storeAlias}")]
        public async Task ApplyCouponToOrder(string coupon, string storeAlias)
        {
            try
            {
                if (string.IsNullOrEmpty(coupon))
                {
                    var resp = new HttpResponseMessage(HttpStatusCode.BadRequest)
                    {
                        Content = new StringContent("Coupon code can not be empty"),
                    };
                    throw new HttpResponseException(resp);
                }

                if (await Order.Instance.ApplyCouponToOrderAsync(coupon, storeAlias))
                {
                    throw new HttpResponseException(HttpStatusCode.OK);
                }
                else
                {
                    throw new HttpResponseException(new HttpResponseMessage((HttpStatusCode)NoChangeResponse)
                    {
                        Content = new StringContent("Discount not modified, better discount found"),
                    });
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
        [HttpDelete]
        [Route("coupon/storealias/{storeAlias}")]
        public async Task RemoveCouponFromOrder(string storeAlias)
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
        [HttpDelete]
        [Route("productkey/{productKey}/coupon/{coupon}/storealias/{storeAlias}")]
        public async Task ApplyCouponToOrderLine(Guid productKey, string coupon, string storeAlias)
        {
            try
            {
                if (await Order.Instance.ApplyCouponToOrderLineAsync(productKey, coupon, storeAlias))
                {
                    throw new HttpResponseException(HttpStatusCode.OK);
                }
                else
                {
                    throw new HttpResponseException(new HttpResponseMessage((HttpStatusCode)NoChangeResponse)
                    {
                        Content = new StringContent("Discount not modified, better discount found"),
                    });
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
        [HttpDelete]
        [Route("productkey/{productKey}/storealias/{storeAlias}")]
        public async Task RemoveCouponFromOrderLine(Guid productKey, string storeAlias)
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
