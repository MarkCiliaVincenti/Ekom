using Ekom.Interfaces;
using Ekom.Models;
using Examine;
using Umbraco.Core.Models;
using Umbraco.Core.Models.PublishedContent;

namespace Ekom.U8.Factories
{
    class ProductFactory : IPerStoreFactory<IProduct>
    {
        public IProduct Create(IPublishedContent item, IStore store)
        {
            return new Product(item, store);
        }

        public IProduct Create(IContent item, IStore store)
        {
            return new Product(item, store);
        }
    }
}
