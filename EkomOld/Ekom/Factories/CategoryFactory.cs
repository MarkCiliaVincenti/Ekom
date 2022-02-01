using Ekom.Interfaces;
using Ekom.Models;
using Examine;
using Umbraco.Core.Models;
using Umbraco.Core.Models.PublishedContent;

namespace Ekom.Factories
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
