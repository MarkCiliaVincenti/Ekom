using Ekom.Interfaces;
using Ekom.Models;

namespace Ekom.U10.Factories
{
    class PaymentProviderFactory : IPerStoreFactory<IPaymentProvider>
    {
        public IPaymentProvider Create(UmbracoContent item, IStore store)
        {
            return new PaymentProvider(item, store);
        }
    }
}
