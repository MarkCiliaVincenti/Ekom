using Ekom.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Web.Models.ContentEditing;
using Umbraco.Web.Trees;

namespace Ekom.Tree
{
    public class EkomSearchTree : ISearchableTree
    {
        public string TreeAlias => "ekomTree";

        private readonly CatalogSearchService _searchService;
        public EkomSearchTree(CatalogSearchService searchService)
        {
            _searchService = searchService;
        }

        public IEnumerable<SearchResultEntity> Search(string query, int pageSize, long pageIndex, out long totalFound, string searchFrom = null)
        {
            totalFound = 0;
            List<SearchResultEntity> searchResults = new List<SearchResultEntity>();
            if (!string.IsNullOrEmpty(query) && query.Length > 2)
            {

                var results = _searchService.QueryCatalog(query, out totalFound);

                foreach (var result in results)
                {
                    searchResults.Add(
                        new SearchResultEntity() { 
                            Name = result.Content.Name, 
                            Id = result.Content.Id, 
                            Key = result.Content.Key, 
                            Score = result.Score,
                            Path = result.Content.Path
                        }
                    );
                }
            }
            return searchResults;
        }
    }
}
