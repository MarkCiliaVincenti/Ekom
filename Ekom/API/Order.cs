using Ekom.Cache;
using Ekom.Interfaces;
using Ekom.Services;
using Ekom.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Umbraco.Core;
using Umbraco.Core.Composing;
using Umbraco.Core.Logging;

namespace Ekom.API
{
    /// <summary>
    /// The Ekom API, get/update/remove operations on orders 
    /// </summary>
    public partial class Order
    {
        /// <summary>
        /// Order Instance
        /// </summary>
        public static Order Instance => Current.Factory.GetInstance<Order>();

        readonly ILogger _logger;
        readonly Configuration _config;
        readonly DiscountCache _discountCache;
        readonly CouponCache _couponCache;
        readonly OrderService _orderService;
        readonly CheckoutService _checkoutService;
        readonly IStoreService _storeSvc;

        /// <summary>
        /// ctor
        /// </summary>
        internal Order(
            Configuration config,
            ILogger logger,
            DiscountCache discountCache,
            CouponCache couponCache,
            OrderService orderService,
            CheckoutService checkoutService,
            IStoreService storeService
        )
        {
            _discountCache = discountCache;
            _orderService = orderService;
            _checkoutService = checkoutService;
            _storeSvc = storeService;
            _couponCache = couponCache;
            _config = config;
            _logger = logger;
        }

        /// <summary>
        /// Get order using cookie data and ekmRequest store.
        /// Retrieves from session if possible, otherwise from SQL.
        /// </summary>
        /// <returns></returns>
        public IOrderInfo GetOrder()
        {
            var store = _storeSvc.GetStoreFromCache();
            return GetOrder(store.Alias);
        }

        /// <summary>
        /// Get order using cookie data and provided store.
        /// Retrieves from session if possible, otherwise from SQL.
        /// </summary>
        /// <returns></returns>
        public IOrderInfo GetOrder(string storeAlias)
        {
            if (string.IsNullOrEmpty(storeAlias))
            {
                throw new ArgumentException(nameof(storeAlias));
            }

            return _orderService.GetOrder(storeAlias);
        }

        /// <summary>
        /// Get order using <see cref="Guid"/>.
        /// </summary>
        /// <returns></returns>
        public IOrderInfo GetOrder(Guid uniqueId)
        {
            return _orderService.GetOrder(uniqueId);
        }

        /// <summary>
        /// Get completed order using cookie data and provided store.
        /// Retrieves from session if possible, otherwise from SQL.
        /// </summary>
        /// <returns></returns>
        public async Task<IOrderInfo> GetCompletedOrderAsync(string storeAlias)
        {
            if (string.IsNullOrEmpty(storeAlias))
            {
                throw new ArgumentException(nameof(storeAlias));
            }

            return await _orderService.GetCompletedOrderAsync(storeAlias)
                .ConfigureAwait(false);
        }

        public async Task UpdateStatusAsync(string storeAlias, OrderStatus newStatus)
        {
            if (string.IsNullOrEmpty(storeAlias))
            {
                throw new ArgumentException(nameof(storeAlias));
            }

            var order = _orderService.GetOrder(storeAlias);
            await _orderService.ChangeOrderStatusAsync(order.UniqueId, newStatus)
                .ConfigureAwait(false);
        }

        public async Task UpdateStatusAsync(OrderStatus newStatus, Guid orderId, string userName = null)
        {
            await _orderService.ChangeOrderStatusAsync(orderId, newStatus, userName)
                .ConfigureAwait(false);
        }

        public async Task<IOrderInfo> AddOrderLineAsync(
            Guid productId,
            int quantity,
            string storeAlias,
            OrderAction? action = null,
            Guid? variantId = null
        )
        {
            if (string.IsNullOrEmpty(storeAlias))
            {
                throw new ArgumentException(nameof(storeAlias));
            }

            return await _orderService.AddOrderLineAsync(productId, quantity, storeAlias, action, variantId)
                .ConfigureAwait(false);
        }

        public async Task<IOrderInfo> UpdateCustomerInformationAsync(Dictionary<string, string> form)
        {
            if (form == null)
            {
                throw new ArgumentNullException(nameof(form));
            }

            return await _orderService.UpdateCustomerInformationAsync(form)
                .ConfigureAwait(false);
        }

        public async Task<IOrderInfo> UpdateShippingInformationAsync(Guid ShippingProvider, string storeAlias)
        {
            if (string.IsNullOrEmpty(storeAlias))
            {
                throw new ArgumentException(nameof(storeAlias));
            }

            return await _orderService.UpdateShippingInformationAsync(ShippingProvider, storeAlias)
                .ConfigureAwait(false);
        }

        public async Task<IOrderInfo> UpdatePaymentInformationAsync(Guid PaymentProvider, string storeAlias)
        {
            if (string.IsNullOrEmpty(storeAlias))
            {
                throw new ArgumentException(nameof(storeAlias));
            }

            return await _orderService.UpdatePaymentInformationAsync(PaymentProvider, storeAlias)
                .ConfigureAwait(false);
        }

        public IOrderInfo RemoveOrderLine(Guid lineId, string storeAlias)
        {
            if (string.IsNullOrEmpty(storeAlias))
            {
                throw new ArgumentException(nameof(storeAlias));
            }

            return _orderService.RemoveOrderLine(lineId, storeAlias);
        }

        public async Task CompleteOrderAsync(Guid orderId)
        {
            await _checkoutService.CompleteAsync(orderId)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Completed orders with <see cref="OrderStatus"/> in one of the last stages
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<IOrderInfo>> GetCompleteCustomerOrdersAsync(int customerId)
        {
            return await _orderService.GetCompleteCustomerOrdersAsync(customerId)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Save multiple hangfire job ids to <see cref="IOrderInfo"/> and db
        /// </summary>
        /// <param name="hangfireJobs">Job IDs to add</param>
        public async Task AddHangfireJobsToOrderAsync(IEnumerable<string> hangfireJobs)
        {
            if (hangfireJobs == null)
            {
                throw new ArgumentNullException(nameof(hangfireJobs));
            }

            var store = _storeSvc.GetStoreFromCache();
            await AddHangfireJobsToOrderAsync(store.Alias, hangfireJobs)
                .ConfigureAwait(false);
        }
        /// <summary>
        /// Save multiple hangfire job ids to <see cref="IOrderInfo"/> and db
        /// </summary>
        /// <param name="storeAlias"></param>
        /// <param name="hangfireJobs">Job IDs to add</param>
        public async Task AddHangfireJobsToOrderAsync(string storeAlias, IEnumerable<string> hangfireJobs)
        {
            if (hangfireJobs == null)
            {
                throw new ArgumentNullException(nameof(hangfireJobs));
            }
            if (string.IsNullOrEmpty(storeAlias))
            {
                throw new ArgumentException(nameof(storeAlias));
            }

            await _orderService.AddHangfireJobsToOrderAsync(storeAlias, hangfireJobs)
                .ConfigureAwait(false);
        }
    }
}
