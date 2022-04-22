using Ekom.Core.Models;
using System.Collections.Generic;

namespace Ekom.Core.Services
{
    interface ISearchService
    {
        IEnumerable<UmbracoContent> QueryCatalog(string query, out long totalRecords);
    }
}
