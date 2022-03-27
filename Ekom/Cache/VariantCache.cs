using Ekom.Core.Interfaces;
using Ekom.Core.Models;
using Microsoft.Extensions.Logging;

namespace Ekom.Core.Cache
{
    class VariantCache : PerStoreCache<IVariant>
    {
        public override string NodeAlias { get; } = "ekmProductVariant";

        public VariantCache(
            Configuration config,
            ILogger<IPerStoreCache<IVariant>> logger,
            IBaseCache<IStore> storeCache,
            IPerStoreFactory<IVariant> perStoreFactory
        ) : base(config, logger, storeCache, perStoreFactory)
        {
        }
    }
}
