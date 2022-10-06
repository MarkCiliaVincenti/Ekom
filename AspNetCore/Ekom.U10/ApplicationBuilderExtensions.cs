using Ekom.API;
using Ekom.AspNetCore;
using Ekom.AspNetCore.Services;
using Ekom.Cache;
using Ekom.Domain.Repositories;
using Ekom.Exceptions;
using Ekom.Interfaces;
using Ekom.Models;
using Ekom.Repositories;
using Ekom.Services;
using Ekom.U10;
using Ekom.U10.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Cms.Core.Cache;

namespace Ekom.U10
{
    public static class ApplicationBuilderExtensions
    {
        public static IServiceCollection AddEkom(this IServiceCollection services)
        {
            services.AddTransient<IStartupFilter, StartupFilter>();

            services.AddAspNetCoreEkom();

            services.AddControllers()
                .AddNewtonsoftJson(option => option.SerializerSettings.ContractResolver = new DefaultContractResolver());

            // What follows are explicit factory constructors for the API methods
            // This is needed since many of their dependencies are internal classes
            // However the API services are public, leaving their constructor public violates
            // C# visibility restrictions
            services.AddTransient<Catalog>(f =>
                new Catalog(
                    f.GetService<ILogger<Catalog>>(),
                    f.GetService<ICacheService>(),
                    f.GetService<Configuration>(),
                    f.GetService<IPerStoreCache<IProduct>>(),
                    f.GetService<IPerStoreCache<ICategory>>(),
                    f.GetService<IPerStoreCache<IProductDiscount>>(),
                    f.GetService<IPerStoreCache<IVariant>>(),
                    f.GetService<IPerStoreCache<IVariantGroup>>(),
                    f.GetService<IStoreService>()
                )
            );
            services.AddTransient<ProductDiscountService>(f =>
                new ProductDiscountService(
                    f.GetService<IPerStoreCache<IProductDiscount>>()
                )
            );

            services.AddTransient<Order>(f =>
                new Order(
                    f.GetService<Configuration>(),
                    f.GetService<ILogger<Order>>(),
                    f.GetService<DiscountCache>(),
                    f.GetService<ICouponCache>(),
                    f.GetService<OrderService>(),
                    f.GetService<CheckoutService>(),
                    f.GetService<IStoreService>()
                )
            );
            services.AddTransient<Providers>(f =>
                new Providers(
                    f.GetService<Configuration>(),
                    f.GetService<ILogger<Providers>>(),
                    f.GetService<IPerStoreCache<IShippingProvider>>(),
                    f.GetService<IPerStoreCache<IPaymentProvider>>(),
                    f.GetService<IBaseCache<IZone>>(),
                    f.GetService<IStoreService>(),
                    f.GetService<CountriesRepository>()
                )
            );
            services.AddTransient<Stock>(f =>
                new Stock(
                    f.GetService<Configuration>(),
                    f.GetService<ILogger<Stock>>(),
                    f.GetService<IBaseCache<StockData>>(),
                    f.GetService<StockRepository>(),
                    f.GetService<DiscountStockRepository>(),
                    f.GetService<IStoreService>(),
                    f.GetService<IPerStoreCache<StockData>>()
                )
            );
            services.AddTransient<Ekom.API.Store>(f =>
                new Ekom.API.Store(
                    f.GetService<ILogger<Ekom.API.Store>>(),
                    f.GetService<IStoreService>(),
                    f.GetService<Configuration>(),
                    f.GetService<INodeService>()
                )
            );
            services.AddTransient<Discounts>(f =>
                 new Discounts(
                    f.GetService<Configuration>(),
                    f.GetService<ILogger<Discounts>>(),
                    f.GetService<IPerStoreCache<IDiscount>>(),
                    f.GetService<IStoreService>()
                 )
             );
            services.AddTransient<IMemberService, MemberService>();
            services.AddTransient<INodeService, NodeService>();
            services.AddTransient<ICacheService, CacheService>();
            services.AddTransient<CatalogSearchService>();
            services.AddTransient<IUmbracoService, UmbracoService>();
            services.AddTransient<IUrlService, UrlService>();
            services.AddTransient<ExamineService>();
            services.AddSingleton<DatabaseFactory>();

            //services.AddMemoryCache();

            services.Configure<MvcOptions>(mvcOptions =>
            {
                mvcOptions.Filters.Add<HttpResponseExceptionFilter>();
            });

            services.AddHttpContextAccessor();

            return services;
        }

        public static IApplicationBuilder UseEkom(this IApplicationBuilder app)
        {
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    "Ekom Controller",
                    "api/{controller}/{action}/{id?}",
                    new { controller = "EkomApi" });
                endpoints.MapControllerRoute(
                    "Ekom Controller",
                    "api/{controller}/{action}/{id?}",
                    new { controller = "EkomCatalog" });
                endpoints.MapControllerRoute(
                    "Ekom Controller",
                    "api/{controller}/{action}/{id?}",
                    new { controller = "EkomOrder" });
            });

            return app;
        }

        private class StartupFilter : IStartupFilter
        {
            public Action<IApplicationBuilder> Configure(Action<IApplicationBuilder> next) => app =>
            {
                app.UseEkomMiddleware();
                next(app);
            };
        }
    }
}
