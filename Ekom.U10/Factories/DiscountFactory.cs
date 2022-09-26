using Ekom.Interfaces;
using Ekom.Models;
using Examine;
using Umbraco.Cms.Core.Models;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace Ekom.U10.Factories
{
    class DiscountFactory : IPerStoreFactory<IDiscount>
    {
        public IDiscount Create(IPublishedContent item, IStore store)
        {
            return new Discount(item, store);
        }

        public IDiscount Create(IContent item, IStore store)
        {
            return new Discount(item, store);
        }
    }
}
