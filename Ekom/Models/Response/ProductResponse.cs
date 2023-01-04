using Ekom.Utilities;
using System.Collections.Generic;
using System.Linq;

namespace Ekom.Models
{
    public class ProductResponse
    {
        public ProductResponse(IEnumerable<IProduct> products, ProductQuery query)
        {

            if (query?.Filters?.Any() == true)
            {
                products = products.Filter(query);
            }

            if (query?.PageSize.HasValue == true && query?.Page.HasValue == true)
            {
                var totalProducts = products.Count();

                Page = query.Page;
                PageSize = query.PageSize;
                PageCount = (totalProducts + PageSize - 1) / PageSize;

                Products = products.Skip((Page.Value - 1) * PageSize.Value).Take(PageSize.Value);

            } else
            {
                Products = products;
            }
        }

        public IEnumerable<IProduct> Products { get; set; }
        public int? PageCount { get; set; }
        public int? PageSize { get; set; }
        public int? Page { get; set; }
    }
}
