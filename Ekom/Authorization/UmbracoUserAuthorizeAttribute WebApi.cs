#if NETFRAMEWORK
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using System.Web.Http.Results;
using System.Net.Http;
using Microsoft.Extensions.DependencyInjection;
using Ekom.Services;

namespace Ekom.Authorization
{
    public sealed class UmbracoUserAuthorizeAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            var securityService = Configuration.Resolver.GetService<ISecurityService>();
            var userGroups = securityService.GetUmbracoUserGroups();

            if (userGroups == null)
            {
                actionContext.Response
                    = actionContext.Request.CreateResponse(HttpStatusCode.Forbidden);
                return;
            }

            base.OnActionExecuting(actionContext);
        }
    }
}
#endif
