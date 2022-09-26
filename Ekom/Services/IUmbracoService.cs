using Ekom.Models;
using System.Collections;
using System.Collections.Generic;

namespace Ekom.Services
{
    public interface IUmbracoService
    {
        IEnumerable<UmbracoDomain> GetDomains(bool includeWildcards = false);
        string GetDictionaryValue(string key);
        string GetDataType(string typeValue);
        IEnumerable<string> GetContent(string guid);
    }
}
