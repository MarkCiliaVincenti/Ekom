using System.Collections.Generic;

namespace Ekom.Core.Models
{
    public interface IPaymentProvider : IPerStoreNodeEntity, IConstrained
    {
        string Name { get; }
        IPrice Price { get; }

        List<IPrice> Prices { get; }
    }
}
