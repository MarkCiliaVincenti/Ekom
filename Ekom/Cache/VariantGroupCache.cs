using Ekom.Core.Interfaces;
using Ekom.Core.Models;
using Microsoft.Extensions.Logging;

namespace Ekom.Core.Cache
{
    class VariantGroupCache : PerStoreCache<IVariantGroup>
    {
        public override string NodeAlias { get; } = "ekmProductVariantGroup";

        public VariantGroupCache(
            Configuration config,
            ILogger<IPerStoreCache<IVariantGroup>> logger,
            IBaseCache<IStore> storeCache,
            IPerStoreFactory<IVariantGroup> perStoreFactory
        ) : base(config, logger, storeCache, perStoreFactory)
        {
        }
    }
}
