using Ekom.Models;
using EkomCore.Models;
using System.Collections.Generic;

namespace EkomCore.Services
{
    public interface IMetafieldService
    {
        IEnumerable<Metafield> GetMetafields();
        List<Metavalue> SerializeMetafields(string jsonValue);
        IEnumerable<MetafieldGrouped> Filters(IEnumerable<IProduct> products, bool filterable = true);
        IEnumerable<IProduct> FilterProducts(IEnumerable<IProduct> products, ProductQuery query);
    }
}
