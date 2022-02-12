using Examine;
using Umbraco.Core.Models;
using Umbraco.Core.Models.PublishedContent;

namespace Ekom.U8.Factories
{
    class CategoryFactory : IPerStoreFactory<ICategory>
    {
        public ICategory Create(IPublishedContent item, IStore store)
        {
            return new Category(item, store);
        }
        public ICategory Create(IContent item, IStore store)
        {
            return new Category(item, store);
        }
    }
}
