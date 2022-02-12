using Ekom.Interfaces;
using Ekom.Models;
using Examine;
using Umbraco.Core.Models;
using Umbraco.Core.Models.PublishedContent;

namespace Ekom.U8.Factories
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
