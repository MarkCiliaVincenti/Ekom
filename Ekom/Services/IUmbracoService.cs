using Ekom.Models;
using System.Collections.Generic;

namespace Ekom.Services
{
    interface IUmbracoService
    {
        IEnumerable<UmbracoDomain> GetDomains(bool includeWildcards = false);
    }
}
