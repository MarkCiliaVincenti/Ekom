using Ekom.Interfaces;
using Ekom.Models;
using Examine;
using Umbraco.Core.Models;
using Umbraco.Core.Models.PublishedContent;

namespace Ekom.Factories
{
    class ShippingProviderFactory : IPerStoreFactory<IShippingProvider>
    {
        public IShippingProvider Create(IPublishedContent item, IStore store)
        {
            return new ShippingProvider(item, store);
        }

        public IShippingProvider Create(IContent item, IStore store)
        {
            return new ShippingProvider(item, store);
        }
    }
}
