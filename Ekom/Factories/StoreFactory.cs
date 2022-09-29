using Ekom.Interfaces;
using Ekom.Models;

namespace Ekom.U10.Factories
{
    class StoreFactory : IObjectFactory<IStore>
    {
        public IStore Create(UmbracoContent item)
        {
            return new Store(item);
        }
    }
}
