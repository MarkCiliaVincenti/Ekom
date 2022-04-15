using Ekom.Core;
using Ekom.Core.Cache;
using Ekom.Core.Interfaces;
using Ekom.Core.Models;
using Microsoft.Extensions.Logging;
using System;

namespace Ekom.Core.Cache
{
    class ProductCache : PerStoreCache<IProduct>
    {
        public override string NodeAlias { get; } = "ekmProduct";

        public ProductCache(
            Configuration config,
            ILogger<IPerStoreCache<IProduct>> logger,
            IBaseCache<IStore> storeCache,
            IPerStoreFactory<IProduct> perStoreFactory,
            IServiceProvider serviceProvider
        ) : base(config, logger, storeCache, perStoreFactory, serviceProvider)
        {
        }
    }
}