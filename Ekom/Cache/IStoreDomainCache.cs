using Ekom.Core.Models;

namespace Ekom.Core.Cache
{
    interface IStoreDomainCache : IBaseCache<UmbracoDomain>
    {
        void AddReplace(UmbracoDomain domain);
    }
}
