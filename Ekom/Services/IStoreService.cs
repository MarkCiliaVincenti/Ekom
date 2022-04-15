using Ekom.Core.Models;
using System.Collections.Generic;

namespace Ekom.Core.Services
{
    interface IStoreService
    {
        IEnumerable<IStore> GetAllStores();
        IStore GetStoreByAlias(string alias);
        IStore GetStoreByDomain(string domain = "");
        IStore GetStoreFromCache();
    }
}
