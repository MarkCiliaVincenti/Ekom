#if !NETFRAMEWORK
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Ekom.Services;

namespace Ekom.Authorization
{
    public sealed class UmbracoUserAuthorizeAttribute : AuthorizeAttribute, IFilterFactory
    {
        public bool IsReusable => false;

        public UmbracoUserAuthorizeAttribute()
        {
        }

        public IFilterMetadata CreateInstance(IServiceProvider serviceProvider) =>
            new RoleRequirementFilter(
                serviceProvider.GetService<ISecurityService>());

        class RoleRequirementFilter : IAuthorizationFilter
        {
            readonly ISecurityService _securityService;

            public RoleRequirementFilter(
                ISecurityService securityService)
            {
                _securityService = securityService;
            }

            public void OnAuthorization(AuthorizationFilterContext context)
            {
                var userGroups = _securityService.GetUmbracoUserGroups();

                if (!userGroups.Any(x => x == "admin"))
                {
                    context.Result = new ForbidResult();
                }
            }
        }
    }
}
#endif
