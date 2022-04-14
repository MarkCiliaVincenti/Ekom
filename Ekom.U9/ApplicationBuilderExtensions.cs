using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ekom.Core.Utilities
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseEkom(this IApplicationBuilder app)
        {
            Configuration.Resolver = app.ApplicationServices;
            return app;
        }
    }
}
