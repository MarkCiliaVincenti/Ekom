using Ekom.AspNetCore.Services;
using Ekom.Cache;
using Ekom.Domain.Repositories;
using Ekom.Factories;
using Ekom.Interfaces;
using Ekom.Models;
using Ekom.Repositories;
using Ekom.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Ekom.AspNetCore
{
    static class Registrations
    {
        public static IServiceCollection AddAspNetCoreEkom(this IServiceCollection services)
        {
            services.AddSingleton<Configuration>();

            services.AddSingleton<IStoreDomainCache, StoreDomainCache>();
            services.AddSingleton<IBaseCache<IStore>, StoreCache>();
            services.AddSingleton<IPerStoreCache<IVariant>, VariantCache>();
            services.AddSingleton<IPerStoreCache<IVariantGroup>, VariantGroupCache>();
            services.AddSingleton<IPerStoreCache<ICategory>, CategoryCache>();
            services.AddSingleton<IPerStoreCache<IProductDiscount>, ProductDiscountCache>();
            services.AddSingleton<IPerStoreCache<IProduct>, ProductCache>();
            services.AddSingleton<IBaseCache<IZone>, ZoneCache>();
            services.AddSingleton<IPerStoreCache<IPaymentProvider>, PaymentProviderCache>();
            services.AddSingleton<IPerStoreCache<IShippingProvider>, ShippingProviderCache>();
            services.AddSingleton<IBaseCache<StockData>, StockCache>();
            services.AddSingleton<IPerStoreCache<StockData>, StockPerStoreCache>();

            // The following database based caches are not strictly related to the preceding ones
            services.AddSingleton<ICouponCache, CouponCache>();
            services.AddSingleton<DiscountCache>();
            services.AddSingleton<IPerStoreCache<IDiscount>>(f => f.GetService<DiscountCache>()); // Lifetime based on preceding line


            services.AddTransient<IStoreService, StoreService>();
            services.AddTransient<OrderService>();
            services.AddTransient<CheckoutService>();
            services.AddTransient<IMailService, MailService>();

            services.AddTransient<CountriesRepository>();
            services.AddTransient<StockRepository>();
            services.AddTransient<DiscountStockRepository>();

            services.AddTransient<OrderRepository>();
            services.AddTransient<CouponRepository>();
            services.AddTransient<ActivityLogRepository>();

            services.AddSingleton<IObjectFactory<IStore>, StoreFactory>();
            services.AddSingleton<IObjectFactory<IZone>, ZoneFactory>();
            services.AddSingleton<IPerStoreFactory<ICategory>, CategoryFactory>();
            services.AddSingleton<IPerStoreFactory<IDiscount>, DiscountFactory>();
            services.AddSingleton<IPerStoreFactory<IPaymentProvider>, PaymentProviderFactory>();
            services.AddSingleton<IPerStoreFactory<IShippingProvider>, ShippingProviderFactory>();
            services.AddSingleton<IPerStoreFactory<IProduct>, ProductFactory>();
            services.AddSingleton<IPerStoreFactory<IProductDiscount>, ProductDiscountFactory>();
            services.AddSingleton<IPerStoreFactory<IVariant>, VariantFactory>();
            services.AddSingleton<IPerStoreFactory<IVariantGroup>, VariantGroupFactory>();

            return services;
        }
    }
}
