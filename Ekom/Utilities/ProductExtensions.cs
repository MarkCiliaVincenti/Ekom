using Ekom.Models;
using EkomCore.Models;
using EkomCore.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Linq;

namespace Ekom.Utilities
{
    public static class ProductExtensions
    {
        public static IEnumerable<MetafieldGrouped> Filters(this IEnumerable<IProduct> products, bool filterable = true)
        {
            var ms = Configuration.Resolver.GetService<IMetafieldService>();

            return ms.Filters(products, filterable);
        }
    }
}
