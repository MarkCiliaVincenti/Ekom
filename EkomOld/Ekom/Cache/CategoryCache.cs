using Ekom.Interfaces;
using Umbraco.Core.Composing;
using Umbraco.Core.Logging;
using Umbraco.Web;

namespace Ekom.Cache
{
    class CategoryCache : PerStoreCache<ICategory>
    {
        public override string NodeAlias { get; } = "ekmCategory";

        public CategoryCache(
            Configuration config,
            ILogger logger,
            IFactory factory,
            IBaseCache<IStore> storeCache,
            IPerStoreFactory<ICategory> perStoreFactory,
            IUmbracoContextFactory context
        ) : base(config, logger, factory, storeCache, perStoreFactory, context)
        {
        }
    }
}
