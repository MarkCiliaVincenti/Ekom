
using Ekom.Core.Interfaces;
using Ekom.Core.Models;
using Microsoft.Extensions.Logging;

namespace Ekom.Core.Cache
{
    class ShippingProviderCache : PerStoreCache<IShippingProvider>
    {
        public override string NodeAlias { get; } = "ekmShippingProvider";

        public ShippingProviderCache(
            Configuration config,
            ILogger<IPerStoreCache<IShippingProvider>> logger,
            IBaseCache<IStore> storeCache,
            IPerStoreFactory<IShippingProvider> perStoreFactory
        ) : base(config, logger, storeCache, perStoreFactory)
        {
        }
    }
}
