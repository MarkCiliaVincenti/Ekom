using Ekom.Interfaces;
using Ekom.Models;
using Examine;
using Umbraco.Core.Models;
using Umbraco.Core.Models.PublishedContent;

namespace Ekom.U8.Factories
{
    class ZoneFactory : IObjectFactory<IZone>
    {
        public IZone Create(IPublishedContent item)
        {
            return new Zone(item);
        }

        public IZone Create(IContent item)
        {
            return new Zone(item);
        }
    }
}
