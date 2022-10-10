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
using Ekom.U10;
using Ekom.U10.Services;
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
using Umbraco.Cms.Core.Cache;

namespace Ekom.U10;

static class ApplicationBuilderExtensions
{
    public static IServiceCollection AddEkom(this IServiceCollection services)
    {
        services.AddSingleton<IStartupFilter, StartupFilter>();

        services.AddAspNetCoreEkom();

        services.AddControllers()
            .AddNewtonsoftJson(option => option.SerializerSettings.ContractResolver = new DefaultContractResolver());

        services.AddTransient<IMemberService, MemberService>();
        services.AddTransient<INodeService, NodeService>();
        services.AddTransient<CatalogSearchService>();
        services.AddTransient<IUmbracoService, UmbracoService>();
        services.AddTransient<IUrlService, UrlService>();
        services.AddTransient<ExamineService>();
        services.AddScoped<BackofficeUserAccessor>();
        services.AddScoped<ISecurityService, SecurityService>();

        return services;
    }

    public static IApplicationBuilder UseEkomMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<EkomMiddleware>();
    }
}
