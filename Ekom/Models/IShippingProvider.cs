using System.Collections.Generic;

namespace Ekom.Core.Models
{
    public interface IShippingProvider : IPerStoreNodeEntity, IConstrained
    {
        IPrice Price { get; }

        List<IPrice> Prices { get; }
    }
}
