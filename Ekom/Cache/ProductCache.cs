using Ekom.Interfaces;
using Umbraco.Core.Composing;
using Umbraco.Core.Logging;
using Umbraco.Web;

namespace Ekom.Cache
{
    class ProductCache : PerStoreCache<IProduct>
    {
        public override string NodeAlias { get; } = "ekmProduct";

        public ProductCache(
            Configuration config,
            ILogger logger,
            IFactory factory,
            IBaseCache<IStore> storeCache,
            IPerStoreFactory<IProduct> perStoreFactory,
            IUmbracoContextFactory context
        ) : base(config, logger, factory, storeCache, perStoreFactory, context)
        {
        }
    }
}
