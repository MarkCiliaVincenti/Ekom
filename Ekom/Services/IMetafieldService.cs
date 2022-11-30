using EkomCore.Models;
using System.Collections.Generic;

namespace EkomCore.Services
{
    public interface IMetafieldService
    {
        IEnumerable<Metafield> GetMetafields();
    }
}
