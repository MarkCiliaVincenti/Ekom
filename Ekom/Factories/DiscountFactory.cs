using Ekom.Interfaces;
using Ekom.Models.Discounts;
using Examine;
using Umbraco.Core.Models;
using Umbraco.Core.Models.PublishedContent;

namespace Ekom.Factories
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
