using Ekom.Interfaces;
using Umbraco.Core.Composing;
using Umbraco.Core.Logging;
using Umbraco.Web;

namespace Ekom.Cache
{
    class ZoneCache : BaseCache<IZone>
    {
        public override string NodeAlias { get; } = "ekmZone";

        /// <summary>
        /// ctor
        /// </summary>
        public ZoneCache(
            Configuration config,
            ILogger logger,
            IFactory factory,
            IObjectFactory<IZone> objectFactory,
            IUmbracoContextFactory context
        ) : base(config, logger, factory, objectFactory, context)
        {
        }
    }
}
