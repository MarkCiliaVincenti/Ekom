using Ekom.Interfaces;
using Ekom.Models;
using Examine;
using Umbraco.Cms.Core.Models;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace Ekom.U10.Factories
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
