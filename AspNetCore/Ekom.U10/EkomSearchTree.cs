using Ekom.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Cms.Core.Trees;
using Umbraco.Cms.Core.Models.ContentEditing;
using Umbraco.Extensions;

namespace Ekom.Tree
{
    [SearchableTree("searchResultFormatter", "configureContentResult", 0)]
    class EkomSearchTree : ISearchableTree
    {
        public string TreeAlias => Umbraco.Cms.Core.Constants.Trees.Content;

        private readonly CatalogSearchService _searchService;
        public EkomSearchTree(CatalogSearchService searchService)
        {
            _searchService = searchService;
        }

        public Task<EntitySearchResults> SearchAsync(string query, int pageSize, long pageIndex, string? searchFrom = null)
        {
            long totalFound = 0;
            List<SearchResultEntity?> searchResults = new List<SearchResultEntity?>();
            if (!string.IsNullOrEmpty(query) && query.Length > 2)
            {
                var results = _searchService.QueryCatalog(query, out totalFound);

                foreach (var result in results)
                {
                    var icon = "icon-document";

                    var content = result.Content;
                    var alias = content.ContentType.Alias;
                    var name = content.Name;

                    if (alias == "ekmProduct")
                    {
                        icon = "icon-loupe";
                        name = content.Name + " (" + content.Value<string>("sku") + ")" + " (" + content.Parent.Name + ")";
                    } else if (alias == "ekmCategory")
                    {
                        icon = "icon-folder";
                    } else if (alias == "ekmProductVariant")
                    {
                        icon = "icon-layers-alt";
                    }

                    var item = new SearchResultEntity()
                    {
                        Name = name,
                        Id = content.Id,
                        Key = content.Key,
                        Score = result.Score,
                        Path = content.Path,
                        Icon = icon
                    };

                    item.AdditionalData["Url"] = content.Url();

                    searchResults.Add(item);
                }

            }

            return Task.FromResult(new EntitySearchResults(searchResults, totalFound));
        }
    }
}
