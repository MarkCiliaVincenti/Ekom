using Ekom.Interfaces;
using Ekom.Models;
using Examine;
using Umbraco.Cms.Core.Models;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace Ekom.U10.Factories
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
