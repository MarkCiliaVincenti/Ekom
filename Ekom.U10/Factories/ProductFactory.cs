using Ekom.Interfaces;
using Ekom.Models;
using Examine;
using Umbraco.Cms.Core.Models;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace Ekom.U10.Factories
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
