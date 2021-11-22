using Ekom.Interfaces;
using Umbraco.Core.Composing;
using Umbraco.Core.Logging;
using Umbraco.Web;

namespace Ekom.Cache
{
    class ShippingProviderCache : PerStoreCache<IShippingProvider>
    {
        public override string NodeAlias { get; } = "ekmShippingProvider";

        public ShippingProviderCache(
            Configuration config,
            ILogger logger,
            IFactory factory,
            IBaseCache<IStore> storeCache,
            IPerStoreFactory<IShippingProvider> perStoreFactory,
            IUmbracoContextFactory context
        ) : base(config, logger, factory, storeCache, perStoreFactory, context)
        {
        }
    }
}
