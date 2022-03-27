using Ekom.Core.Interfaces;
using Ekom.Core.Models;
using Microsoft.Extensions.Logging;

namespace Ekom.Core.Cache
{
    class ZoneCache : BaseCache<IZone>
    {
        public override string NodeAlias { get; } = "ekmZone";

        /// <summary>
        /// ctor
        /// </summary>
        public ZoneCache(
            Configuration config,
            ILogger<BaseCache<IZone>> logger,
            IObjectFactory<IZone> objectFactory
        ) : base(config, logger, objectFactory)
        {
        }
    }
}
