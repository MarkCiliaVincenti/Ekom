using Ekom.Interfaces;
using Ekom.Models;
using Examine;
using Umbraco.Cms.Core.Models;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace Ekom.U10.Factories
{
    class PaymentProviderFactory : IPerStoreFactory<IPaymentProvider>
    {
        public IPaymentProvider Create(IPublishedContent item, IStore store)
        {
            return new PaymentProvider(item, store);
        }

        public IPaymentProvider Create(IContent item, IStore store)
        {
            return new PaymentProvider(item, store);
        }
    }
}
