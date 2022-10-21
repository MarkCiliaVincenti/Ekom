using Ekom.Models;
using EkomCore.Models.Umbraco;
using System;
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
        IEnumerable<UmbracoLanguage> GetLanguages();
        object GetDataTypeByAlias(string contentTypeAlias, string propertyAlias);
        object GetDataTypeById(Guid id);
        IEnumerable<object> GetNonEkomDataTypes();
    }
}
