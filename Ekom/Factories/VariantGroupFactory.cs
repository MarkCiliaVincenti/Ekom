using Ekom.Interfaces;
using Ekom.Models;

namespace Ekom.U10.Factories
{
    class VariantGroupFactory : IPerStoreFactory<IVariantGroup>
    {
        public IVariantGroup Create(UmbracoContent item, IStore store)
        {
            return new VariantGroup(item, store);
        }
    }
}
