using Ekom.Interfaces;
using Ekom.Models;
using Examine;
using Umbraco.Core.Models;
using Umbraco.Core.Models.PublishedContent;

namespace Ekom.U10.Factories
{
    class VariantFactory : IPerStoreFactory<IVariant>
    {
        public IVariant Create(IPublishedContent item, IStore store)
        {
            return new Variant(item, store);
        }

        public IVariant Create(IContent item, IStore store)
        {
            return new Variant(item, store);
        }
    }
}
