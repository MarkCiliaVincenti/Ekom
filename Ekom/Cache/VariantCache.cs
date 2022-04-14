using Ekom.Core.Interfaces;
using Ekom.Core.Models;
using Microsoft.Extensions.Logging;
using System;

namespace Ekom.Core.Cache
{
    class VariantCache : PerStoreCache<IVariant>
    {
        public override string NodeAlias { get; } = "ekmProductVariant";

        public VariantCache(
            Configuration config,
            ILogger<IPerStoreCache<IVariant>> logger,
            IBaseCache<IStore> storeCache,
            IPerStoreFactory<IVariant> perStoreFactory,
            IServiceProvider serviceProvider
        ) : base(config, logger, storeCache, perStoreFactory, serviceProvider)
        {
        }
    }
}
