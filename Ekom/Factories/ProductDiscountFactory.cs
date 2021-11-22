using Ekom.Interfaces;
using Ekom.Models;
using Ekom.Models.Discounts;
using Examine;
using Umbraco.Core.Models;
using Umbraco.Core.Models.PublishedContent;

namespace Ekom.Factories
{
    public class ProductDiscountFactory : IPerStoreFactory<IProductDiscount>
    {
        public IProductDiscount Create(IPublishedContent item, IStore store)
        {
            return new ProductDiscount(item, store);
        }

        public IProductDiscount Create(IContent item, IStore store)
        {
            return new ProductDiscount(item, store);
        }
    }
}
