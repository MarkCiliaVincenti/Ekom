using Ekom.Core.Interfaces;
using Ekom.Core.Models;
using Microsoft.Extensions.Logging;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using GlobalCouponCache
    = System.Collections.Concurrent.ConcurrentDictionary<string, Ekom.Core.Models.CouponData>;

namespace Ekom.Core.Cache
{
    /// <inheritdoc />
    class CouponCache : ICouponCache
    {
        readonly ILogger _logger;
        readonly IUmbracoDatabaseFactory _databaseFactory;

        public GlobalCouponCache Cache { get; } = new GlobalCouponCache();

        public CouponCache(
            ILogger<CouponCache> logger,
            IUmbracoDatabaseFactory databaseFactory
        )
        {
            _logger = logger;
            _databaseFactory = databaseFactory;
        }

        /// <inheritdoc />
        public void FillCache()
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            _logger.LogInformation("Starting to fill coupon cache...");

            List<CouponData> allCoupons;
            using (var db = _databaseFactory.CreateDatabase())
            {
                //var db = scope.Database;
                allCoupons = db.FetchAsync<CouponData>().Result;
                //scope.Complete();
            }

            foreach (var coupon in allCoupons)
            {
                Cache[coupon.CouponCode.ToLowerInvariant()] = coupon;
            }

            stopwatch.Stop();

            _logger.LogInformation(
                "Finished filling Coupon cache with {Count} items. Time it took to fill: {Elapsed}",
                allCoupons.Count,
                stopwatch.Elapsed);
        }

        /// <inheritdoc />
        public void AddReplace(CouponData coupon)
        {
            Cache[coupon.CouponCode.ToLowerInvariant()] = coupon;
        }

        /// <inheritdoc />
        public void Remove(CouponData coupon)
        {
            Cache.TryRemove(coupon.CouponCode.ToLowerInvariant(), out _);
        }
    }
}
