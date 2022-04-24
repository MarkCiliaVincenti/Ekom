using Ekom.Models;
using System.Collections.Generic;

namespace Ekom.Services
{
    public interface IUmbracoService
    {
        IEnumerable<UmbracoDomain> GetDomains(bool includeWildcards = false);
        string GetDictionaryValue(string key);
    }
}
