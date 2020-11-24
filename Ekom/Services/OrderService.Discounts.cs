using Ekom.API;
using Ekom.Exceptions;
using Ekom.Interfaces;
using Ekom.Models;
using Ekom.Models.Data;
using Ekom.Models.Discounts;
using Ekom.Models.OrderedObjects;
using Ekom.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Umbraco.Core.Logging;

namespace Ekom.Services
{
    partial class OrderService // : IOrderService
    {

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<bool> ApplyDiscountToOrderAsync(
            IDiscount discount,
            string storeAlias = null,
            string coupon = null,
            OrderInfo orderInfo = null
        )
        {
            orderInfo = orderInfo ?? GetOrder(storeAlias);

            if (ApplyDiscountToOrder(discount, orderInfo, coupon))
            {
                await UpdateOrderAndOrderInfoAsync(orderInfo)
                    .ConfigureAwait(false);

                return true;
            }
            return false;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private bool ApplyDiscountToOrder(
            IDiscount discount,
            OrderInfo orderInfo,
            string coupon = null
        )
        {
            if (discount is IProductDiscount)
            {
                // This is not correct usage of an IProductDiscount, 
                // they should be automatically applied on OrderLine creation or use
                // ApplyDiscountToOrderLineProductAsync
                throw new NotSupportedException(
                    "Ekom does not currently support comparing or applying ProductDiscounts to OrderInfo, IProductDiscount however inherits from IDiscount for simplicities sake"
                );
            }

            if (IsBetterDiscount(orderInfo, discount) && IsDiscountApplicable(orderInfo, discount))
            {
                // Remove worse coupons from orderlines
                foreach (OrderLine line in orderInfo.OrderLines.Where(line => line.Discount != null))
                {
                    if (!discount.Stackable || IsBetterDiscount(line, discount))
                    {
                        line.Discount = null;
                        line.Coupon = null;
                    }
                }

                orderInfo.Discount = new OrderedDiscount(discount);
                orderInfo.Coupon = coupon;

                return true;
            }

            return false;
        }

        public async Task RemoveDiscountFromOrderAsync(string storeAlias)
        {
            var orderInfo = GetOrder(storeAlias);

            RemoveDiscountFromOrder(orderInfo);
            await UpdateOrderAndOrderInfoAsync(orderInfo).ConfigureAwait(false);
        }
        private void RemoveDiscountFromOrder(OrderInfo orderInfo)
        {
            orderInfo.Discount = null;
            orderInfo.Coupon = null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <exception cref="ProductNotFoundException"></exception>
        /// <exception cref="OrderLineNotFoundException"></exception>
        /// <returns></returns>
        public async Task<bool> ApplyDiscountToOrderLineProductAsync(
            Guid productKey,
            IDiscount discount,
            string storeAlias = null,
            string coupon = null,
            OrderInfo orderInfo = null
        )
        {
            IProduct product = Catalog.Instance.GetProduct(productKey);

            if (product == null)
            {
                throw new ProductNotFoundException($"Unable to find product: {productKey}");
            }

            return await ApplyDiscountToOrderLineProductAsync(
                product,
                discount,
                storeAlias,
                coupon,
                orderInfo
            ).ConfigureAwait(false);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <exception cref="ProductNotFoundException"></exception>
        /// <exception cref="OrderLineNotFoundException"></exception>
        /// <returns></returns>
        public async Task<bool> ApplyDiscountToOrderLineProductAsync(
            IProduct product,
            IDiscount discount,
            string storeAlias = null,
            string coupon = null,
            OrderInfo orderInfo = null
        )
        {

            orderInfo = orderInfo ?? GetOrder(storeAlias);
            OrderLine orderLine
                = orderInfo.OrderLines.FirstOrDefault(line => line.Product.Key == product.Key)
                as OrderLine;

            if (orderLine == null)
            {
                throw new OrderLineNotFoundException($"Unable to find order line with product key: {product.Key}");
            }

            return await ApplyDiscountToOrderLineAsync(
                orderLine,
                discount,
                orderInfo,
                coupon
            ).ConfigureAwait(false);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <exception cref="OrderLineNotFoundException"></exception>
        /// <returns></returns>
        public async Task<bool> ApplyDiscountToOrderLineAsync(
            Guid lineKey,
            IDiscount discount,
            string storeAlias = null,
            string coupon = null,
            OrderInfo orderInfo = null
        )
        {
            orderInfo = orderInfo ?? GetOrder(storeAlias);
            OrderLine orderLine
                = orderInfo.OrderLines.FirstOrDefault(line => line.Key == lineKey)
                as OrderLine;

            if (orderLine == null)
            {
                throw new OrderLineNotFoundException($"Unable to find order line: {lineKey}");
            }

            return await ApplyDiscountToOrderLineAsync(
                orderLine,
                discount,
                orderInfo,
                coupon
            ).ConfigureAwait(false);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <exception cref="OrderLineNotFoundException"></exception>
        /// <returns></returns>
        private async Task<bool> ApplyDiscountToOrderLineAsync(
            OrderLine orderLine,
            IDiscount discount,
            OrderInfo orderInfo,
            string coupon = null
        )
        {
            _logger.Debug<OrderService>("Applying discount to orderline");

            if (IsDiscountApplicable(orderInfo, orderLine, discount))
            {
                // If a discount is applied to the OrderLine, 
                // assume that discount was better than thecurrent OrderInfo discount. 
                // (We have checks in place that make sure that stays true)
                if (orderLine.Discount != null)
                {
                    if (IsBetterDiscount(orderLine, discount))
                    {
                        orderLine.Discount = new OrderedDiscount(discount);
                        orderLine.Coupon = coupon;

                        await UpdateOrderAndOrderInfoAsync(orderInfo)
                            .ConfigureAwait(false);

                        _logger.Debug<OrderService>("Successfully applied discount to orderline");
                        return true;
                    }
                }
                else
                {
                    // Apply cart discount on line for comparison with new discount
                    // was null so we are never overriding
                    orderLine.Discount = orderInfo.Discount;

                    if ((orderInfo.Discount == null || orderInfo.Discount.Stackable)
                    && IsBetterDiscount(orderLine, discount))
                    {
                        orderLine.Discount = new OrderedDiscount(discount);
                        orderLine.Coupon = coupon;

                        await UpdateOrderAndOrderInfoAsync(orderInfo)
                            .ConfigureAwait(false);

                        _logger.Debug<OrderService>("Successfully applied discount to orderline");
                        return true;
                    }
                    // When we add a new OrderLine, it might have an applicable ProductDiscount
                    // If the OrderInfo has an exclusive discount we check if the total order price goes down
                    // on applying the ProductDiscount, if so we throw away the OrderInfo discount and use the ProductDiscount instead.
                    else if (orderInfo.Discount?.Stackable == false && IsBetterDiscount(orderInfo, discount))
                    {
                        // It's possible that there exist previous OrderLine's that the ProductDiscount applies to
                        // in that case we assume this new orderline tipped the calculation in favor of this given ProductDiscount
                        // and that the older lines are missing this new about to be applied ProductDiscount (since the OrderInfo one was inclusive)
                        foreach (var line in orderInfo.orderLines)
                        {
                            if (IsDiscountApplicable(orderInfo, line, discount))
                            {
                                line.Discount = new OrderedDiscount(discount);
                            }
                        }

                        orderInfo.Discount = null;
                        _logger.Debug<OrderService>("Replaced exclusive OrderInfo discount with a ProductDiscount");
                        return true;
                    }
                    // Only other case is a worse discount

                    orderLine.Discount = null;
                }
            }

            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <exception cref="OrderLineNotFoundException"></exception>
        /// <returns></returns>
        public async Task RemoveDiscountFromOrderLineAsync(Guid productKey, string storeAlias)
        {
            var orderInfo = GetOrder(storeAlias);
            var orderLine = orderInfo.OrderLines.FirstOrDefault(line => line.Product.Key == productKey)
                as OrderLine;

            if (orderLine == null)
            {
                throw new OrderLineNotFoundException($"Unable to find order line: {productKey}");
            }

            RemoveDiscountFromOrderLine(orderLine);

            await UpdateOrderAndOrderInfoAsync(orderInfo)
                .ConfigureAwait(false);
        }
        private void RemoveDiscountFromOrderLine(OrderLine orderLine)
        {
            if (orderLine == null)
            {
                throw new ArgumentException(nameof(OrderLine));
            }

            orderLine.Discount = null;
            orderLine.Coupon = null;
        }

        private bool IsBetterDiscount(OrderInfo orderInfo, IDiscount discount)
        {
            if (orderInfo.Discount == null && !discount.Stackable)
            {
                var oldTotal = orderInfo.ChargedAmount.Value;

                orderInfo.Discount = new OrderedDiscount(discount);

                var result = orderInfo.ChargedAmount.Value < oldTotal;

                orderInfo.Discount = null;

                return result;
            }

            if (orderInfo.Discount == null)
            {
                return true;
            }

            if (orderInfo.Discount.Key == discount.Key)
            {
                // throwing an exception allows callers to differentiate between an attempt to apply a worse discount
                // and a duplicate discount application
                // This can then be handled in api controllers or frontend code to display the appropriate error.
                throw new DiscountNotFoundException($"Can't add the same discount to order twice.");
            }

            if (discount is IProductDiscount productDiscount)
            {
                var oldTotal = orderInfo.ChargedAmount.Value;

                // Save original discounts
                var prevOrderDiscount = orderInfo.Discount;
                var prevDiscounts = new List<OrderedDiscount>();
                foreach (var line in orderInfo.orderLines)
                {
                    prevDiscounts.Add(line.Discount);

                    if (IsDiscountApplicable(orderInfo, line, productDiscount))
                    {
                        line.Discount = new OrderedDiscount(productDiscount);
                    }
                }
                // In case of an exclusive discount, we remove since OrderInfo ChargedAmount ignores
                // product discounts when an exclusive order discount is applied.
                // This ignoring happens for comparison reasons and is explained in ChargedAmount.
                orderInfo.Discount = null;
                // Compare
                var result = orderInfo.ChargedAmount.Value < oldTotal;

                // Reset to previous discounts
                orderInfo.Discount = prevOrderDiscount;
                for (var x = 0; x < orderInfo.OrderLines.Count; x++)
                {
                    orderInfo.orderLines[x].Discount = prevDiscounts.ElementAt(x);
                }

                return result;
            }
            else
            {
                // In case of comparing an Exclusive to an inclusive discount, this simple CompareTo
                // does not apply
                //if (orderInfo.Discount.Type == discount.Type)
                //{
                //    return discount.CompareTo(orderInfo.Discount) > 0;
                //}

                var oldDiscount = orderInfo.Discount;
                var oldTotal = orderInfo.ChargedAmount.Value;

                orderInfo.Discount = new OrderedDiscount(discount);

                var result = orderInfo.ChargedAmount.Value < oldTotal;

                orderInfo.Discount = oldDiscount;

                return result;
            }
        }

        private bool IsBetterDiscount(OrderLine orderLine, IDiscount discount)
        {
            if (orderLine.Discount == null)
            {
                return true;
            }

            if (orderLine.Discount.Type == discount.Type)
            {
                return discount.CompareTo(orderLine.Discount) > 0;
            }

            var oldDiscount = orderLine.Discount;
            var oldTotal = orderLine.Amount;

            orderLine.Discount = new OrderedDiscount(discount);

            var result = orderLine.Amount.Value < oldTotal.Value;

            orderLine.Discount = oldDiscount;

            return result;
        }

        /// <summary>
        /// Although Discounts are store specific, coupons are not.
        /// We therefore 
        /// </summary>
        /// <param name="Key"></param>
        public void CouponApply(Guid Key)
        {
            var defStore = _storeSvc.GetAllStores().First();
            var discount = _discountCache[defStore.Alias][Key];

            (discount as Discount)?.OnCouponApply();
        }

        /// <summary>
        /// Verifies all <see cref="Discount"/>'s match their constraints.
        /// Removes non-compliant <see cref="Discount"/>'s
        /// 
        /// Gets called on OrderInfo updates, constraints may become invalid if the order total changes.
        /// </summary>
        private void VerifyDiscounts(OrderInfo orderInfo)
        {
            var total = orderInfo.OrderLineTotal.Value;
            var storeAlias = orderInfo.StoreInfo.Alias;

            // Verify order discount constraints
            if (orderInfo.Discount != null
            && !orderInfo.Discount.Constraints.IsValid(
                storeAlias,
                total))
            {
                RemoveDiscountFromOrder(orderInfo);
            }

            //var curStoreDiscCache = _discountCache.GlobalDiscounts[storeAlias];

            //var gds = curStoreDiscCache
            //    .Where(gd => gd.Value.Constraints.IsValid(storeAlias, total))
            //    .Select(gd => gd.Value)
            //    .ToList();

            //// Try apply global order discounts
            //foreach (var gd in gds)
            //{
            //    //ApplyDiscountToOrder(gd, orderInfo, coupon: null);
            //}

            // Verify order line discount constraints
            foreach (var line in orderInfo.orderLines)
            {
                if (line.Discount != null)
                {
                    if (line.Discount?.Constraints.IsValid(storeAlias, total) == false
                    || !IsDiscountApplicable(orderInfo, line, line.Discount))
                    {
                        RemoveDiscountFromOrderLine(line);
                    }
                }
            }
        }

        /// <summary>
        /// Do constraints hold for the given discount
        /// </summary>
        /// <param name="orderInfo"></param>
        /// <param name="discount"></param>
        /// <returns></returns>
        private bool IsDiscountApplicable(IOrderInfo orderInfo, IDiscount discount)
            => discount.Constraints.IsValid(orderInfo.StoreInfo.Culture, orderInfo.OrderLineTotal.Value);

        /// <summary>
        /// Do constraints hold and do discount items match if any
        /// </summary>
        /// <param name="orderInfo"></param>
        /// <param name="orderLine"></param>
        /// <param name="discount"></param>
        /// <returns></returns>
        private bool IsDiscountApplicable(IOrderInfo orderInfo, IOrderLine orderLine, IDiscount discount)
        {
            return discount.Constraints.IsValid(orderInfo.StoreInfo.Culture, orderInfo.OrderLineTotal.Value)
                && (discount.DiscountItems.Count == 0
                || (orderLine.Product.Path.Split(',').Intersect(discount.DiscountItems).Any())
                || (orderLine.Product.Properties.GetPropertyValue("categories").Split(',').Select(x => NodeHelper.GetNodeByUdi(x)?.Id.ToString()).Intersect(discount.DiscountItems).Any())
                );
        }

        public async Task InsertCouponCodeAsync(string couponCode, int numberAvailable, Guid discountId)
        {
            if (string.IsNullOrEmpty(couponCode))
            {
                throw new ArgumentException(nameof(couponCode));
            }

            if (discountId == Guid.Empty)
            {
                throw new ArgumentException(nameof(discountId));
            }

            await _couponRepository.InsertCouponAsync(new CouponData()
            {
                CouponCode = couponCode.ToLowerInvariant(),
                CouponKey = Guid.NewGuid(),
                DiscountId = discountId,
                NumberAvailable = numberAvailable
            }).ConfigureAwait(false);
        }

        public async Task RemoveCouponCodeAsync(string couponCode, Guid discountId)
        {
            if (string.IsNullOrEmpty(couponCode))
            {
                throw new ArgumentException(nameof(couponCode));
            }

            if (discountId == Guid.Empty)
            {
                throw new ArgumentException(nameof(discountId));
            }

            await _couponRepository.RemoveCouponAsync(discountId, couponCode)
                .ConfigureAwait(false);
        }

        public async Task<List<CouponData>> GetCouponsForDiscountAsync(Guid discountId)
        {
            if (discountId == Guid.Empty)
            {
                throw new ArgumentException(nameof(discountId));
            }

            return await _couponRepository.GetCouponsForDiscountAsync(discountId)
                .ConfigureAwait(false);
        }
    }
}
