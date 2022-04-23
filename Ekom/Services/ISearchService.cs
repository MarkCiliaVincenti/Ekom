using Ekom.Models;
using System.Collections.Generic;

namespace Ekom.Services
{
    interface ISearchService
    {
        IEnumerable<UmbracoContent> QueryCatalog(string query, out long totalRecords);
    }
}
