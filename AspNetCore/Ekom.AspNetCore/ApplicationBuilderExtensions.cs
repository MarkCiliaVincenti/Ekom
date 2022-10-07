using Ekom.API;
using Ekom.AspNetCore;
using Ekom.AspNetCore.Services;
using Ekom.Authorization;
using Ekom.Cache;
using Ekom.Domain.Repositories;
using Ekom.Exceptions;
using Ekom.Interfaces;
using Ekom.Models;
using Ekom.Repositories;
using Ekom.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
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

namespace Ekom.AspNetCore
{
    static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseEkomControllers(this IApplicationBuilder app)
        {
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    "Ekom Api Controller",
                    "api/{controller}/{action}/{id?}",
                    new { controller = "EkomApi" });
                endpoints.MapControllerRoute(
                    "Ekom Catalog Controller",
                    "api/{controller}/{action}/{id?}",
                    new { controller = "EkomCatalog" });
                endpoints.MapControllerRoute(
                    "Ekom Order Controller",
                    "api/{controller}/{action}/{id?}",
                    new { controller = "EkomOrder" });
                endpoints.MapControllerRoute(
                    "Ekom Backoffice Controller",
                    "api/{controller}/{action}/{id?}",
                    new { controller = "EkomBackofficeApi" });
            });

            return app;
        }
    }
}
