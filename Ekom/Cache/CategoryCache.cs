using Ekom.Core.Interfaces;
using Ekom.Core.Models;
using Microsoft.Extensions.Logging;

namespace Ekom.Core.Cache
{
    class CategoryCache : PerStoreCache<ICategory>
    {
        public override string NodeAlias { get; } = "ekmCategory";

        public CategoryCache(
            Configuration config,
            ILogger<IPerStoreCache<ICategory>> logger,
            IBaseCache<IStore> storeCache,
            IPerStoreFactory<ICategory> perStoreFactory
        ) : base(config, logger, storeCache, perStoreFactory)
        {
        }
    }
}
