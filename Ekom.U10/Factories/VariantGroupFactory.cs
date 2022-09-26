using Ekom.Interfaces;
using Ekom.Models;
using Examine;
using Umbraco.Core.Models;
using Umbraco.Core.Models.PublishedContent;

namespace Ekom.U10.Factories
{
    class VariantGroupFactory : IPerStoreFactory<IVariantGroup>
    {
        public IVariantGroup Create(IPublishedContent item, IStore store)
        {
            return new VariantGroup(item, store);
        }

        public IVariantGroup Create(IContent item, IStore store)
        {
            return new VariantGroup(item, store);
        }
    }
}
