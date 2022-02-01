using Ekom.Interfaces;
using Umbraco.Core.Composing;
using Umbraco.Core.Logging;
using Umbraco.Web;

namespace Ekom.Cache
{
    class VariantCache : PerStoreCache<IVariant>
    {
        public override string NodeAlias { get; } = "ekmProductVariant";

        public VariantCache(
            Configuration config,
            ILogger logger,
            IFactory factory,
            IBaseCache<IStore> storeCache,
            IPerStoreFactory<IVariant> perStoreFactory,
            IUmbracoContextFactory context
        ) : base(config, logger, factory, storeCache, perStoreFactory, context)
        {
        }
    }
}
