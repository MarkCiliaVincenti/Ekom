using Ekom.Interfaces;
using Ekom.Models;

namespace Ekom.U10.Factories
{
    class ShippingProviderFactory : IPerStoreFactory<IShippingProvider>
    {
        public IShippingProvider Create(UmbracoContent item, IStore store)
        {
            return new ShippingProvider(item, store);
        }
    }
}
