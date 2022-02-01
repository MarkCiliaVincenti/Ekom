using Ekom.Interfaces;
using Ekom.Models;
using Examine;
using Umbraco.Core.Models;
using Umbraco.Core.Models.PublishedContent;

namespace Ekom.Factories
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
