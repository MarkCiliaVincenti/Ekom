using Ekom.Core.Models;
using System.Collections.Generic;

namespace Ekom.Core.Services
{
    interface IUmbracoService
    {
        IEnumerable<UmbracoDomain> GetDomains(bool includeWildcards = false);
    }
}
