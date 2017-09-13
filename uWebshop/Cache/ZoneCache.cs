using Examine;
using uWebshop.Models;
using uWebshop.Services;

namespace uWebshop.Cache
{
    class ZoneCache : BaseCache<Zone>
    {
        public override string NodeAlias { get; } = "uwbsZone";

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="logFac"></param>
        /// <param name="config"></param>
        /// <param name="examineManager"></param>
        public ZoneCache(
            ILogFactory logFac,
            Configuration config,
            ExamineManager examineManager
        )
        {
            _config = config;
            _examineManager = examineManager;
            _log = logFac.GetLogger(typeof(ZoneCache));
        }

        private Zone New(SearchResult r, Store store)
        {
            return new Zone(r);
        }
    }
}
