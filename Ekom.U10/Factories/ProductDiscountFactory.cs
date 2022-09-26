using Ekom.Interfaces;
using Ekom.Models;
using Examine;
using Umbraco.Cms.Core.Models;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace Ekom.U10.Factories
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
