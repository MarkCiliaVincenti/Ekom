using Ekom.Interfaces;
using Examine;
using System.Collections.Generic;
using Umbraco.Core.Models;
using Umbraco.Core.Models.PublishedContent;

namespace Ekom.Models
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
        /// Construct Zone from Examine Search Result
        /// </summary>
        /// <param name="item"></param>
        public Zone(IPublishedContent item) : base(item) { }

        /// <summary>
        /// Construct zone from umbraco publish event
        /// </summary>
        /// <param name="item"></param>
        public Zone(IContent item) : base(item) { }
    }
}
