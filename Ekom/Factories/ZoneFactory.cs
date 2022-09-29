using Ekom.Interfaces;
using Ekom.Models;

namespace Ekom.U10.Factories
{
    class ZoneFactory : IObjectFactory<IZone>
    {
        public IZone Create(UmbracoContent item)
        {
            return new Zone(item);
        }
    }
}
