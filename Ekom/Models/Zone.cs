using System.Collections.Generic;

namespace Ekom.Core.Models
{
    /// <summary>
    /// A grouping of countries, used to map payment providers and shipping providers to regions
    /// </summary>
    public class Zone : NodeEntity, IZone
    {
        /// <summary>
        /// Countries encompassing this Zone
        /// </summary>
        public IEnumerable<string> Countries => Properties.ContainsKey("zoneSelector") ? Properties["zoneSelector"].Split(',') : Properties["zone"].Split(',');

        /// <summary>
        /// ctor
        /// </summary>
        public Zone() : base() { }

        /// <summary>
        /// Construct Zone
        /// </summary>
        /// <param name="item"></param>
        public Zone(UmbracoContent item) : base(item) { }

    }
}
