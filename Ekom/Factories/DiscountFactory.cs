using Ekom.Interfaces;
using Ekom.Models;

namespace Ekom.U10.Factories
{
    class DiscountFactory : IPerStoreFactory<IDiscount>
    {
        public IDiscount Create(UmbracoContent item, IStore store)
        {
            return new Discount(item, store);
        }
    }
}
