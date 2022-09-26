using Ekom.Interfaces;
using Ekom.Models;
using Examine;
using Umbraco.Cms.Core.Models;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace Ekom.U10.Factories
{
    class StoreFactory : IObjectFactory<IStore>
    {
        public IStore Create(IPublishedContent item)
        {
            return new Store(item);
        }

        public IStore Create(IContent item)
        {
            return new Store(item);
        }
    }
}
