using Ekom.Models;
using EkomCore.Models;
using EkomCore.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;

namespace Ekom.Utilities
{
    public static class ProductExtensions
    {
        public static IEnumerable<MetafieldGrouped> Filters(this IEnumerable<IProduct> products, bool filterable = true)
        {
            var ms = Configuration.Resolver.GetService<IMetafieldService>();

            return ms.Filters(products, filterable);
        }
        public static IEnumerable<IProduct> Filter(this IEnumerable<IProduct> products, ProductQuery query)
        {
            var ms = Configuration.Resolver.GetService<IMetafieldService>();

            return ms.FilterProducts(products, query);
        }
    }
}
