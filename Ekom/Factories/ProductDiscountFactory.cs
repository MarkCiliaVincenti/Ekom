using Ekom.Interfaces;
using Ekom.Models;

namespace Ekom.U10.Factories
{
    public class ProductDiscountFactory : IPerStoreFactory<IProductDiscount>
    {
        public IProductDiscount Create(UmbracoContent item, IStore store)
        {
            return new ProductDiscount(item, store);
        }
    }
}
