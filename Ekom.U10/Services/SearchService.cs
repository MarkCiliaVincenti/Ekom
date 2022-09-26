using Ekom.Models;
using Ekom.Services;
using Ekom.U10.Models;
using Examine;
using Examine.Lucene.Providers;
using Examine.Lucene.Search;
using Examine.Search;
using Lucene.Net.QueryParsers.Classic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Umbraco.Cms.Core;
using Umbraco.Cms.Core.Logging;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.Web;
using Microsoft.Extensions.Logging;
using Umbraco.Cms.Infrastructure.Examine;
using static Ekom.Utilities.SearchHelper;

namespace Ekom.Services
{
    class SearchService : ISearchService
    {
        private readonly ILogger _logger;
        private readonly IPublishedContentQuery _query;
        public SearchService(IPublishedContentQuery query, ILogger logger)
        {
            _logger = logger;
            _query = query;
        }
        public IEnumerable<UmbracoContent> QueryCatalog(string query, out long totalRecords)
        {
            totalRecords = 0;
            var luceneQuery = new StringBuilder();

            try
            {
                if (ExamineManager.Instance.TryGetIndex("InternalIndex", out var index) || !(index is IUmbracoIndex umbIndex))
                {
                    var fields = new List<SearchField>()
                    {
                        new SearchField()
                        {
                            Name = "nodeName",
                            Booster = "^2.0"
                        },
                        new SearchField()
                        {
                            Name = "sku",
                            Booster = "^3.0",
                            SearchType = SearchType.Wildcard
                        },
                        new SearchField()
                        {
                            Name = "title",
                            Booster = "^2.0"
                        },
                        new SearchField()
                        {
                            Name = "id",
                            Booster = "^10.0",
                            SearchType = SearchType.Exact
                        }
                    };

                    var searcher = (BaseLuceneSearcher)index.GetSearcher();

                    var queryWithOutStopWords = query.RemoveStopWords();

                    var cleanQuery = RemoveDiacritics(string.IsNullOrEmpty(queryWithOutStopWords) ? query : queryWithOutStopWords);

                    var searchTerms = cleanQuery
                        .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(QueryParser.Escape);

                    int i = 0;

                    foreach (var term in searchTerms)
                    {
                        if (i != 0)
                        {
                            luceneQuery.Append(" AND ");
                        }

                        if (i == 0)
                        {
                            luceneQuery.Append("+");
                        }

                        if (string.IsNullOrEmpty(queryWithOutStopWords))
                        {
                            luceneQuery.Append(" (");
                            luceneQuery.Append("*" + term + "*");
                            luceneQuery.Append(" " + term + ("~" + "0.5"));
                            luceneQuery.Append(")");
                        }
                        else
                        {
                            luceneQuery.Append(" (");
                            foreach (var field in fields)
                            {
                                luceneQuery.Append(" (");
                                if (field.SearchType == SearchType.Wildcard || field.SearchType == SearchType.FuzzyAndWilcard)
                                {
                                    luceneQuery.Append("(" + FieldCultureName(field.Name) + ": " + "*" + term + "*" + ")" + (!string.IsNullOrEmpty(field.Booster) ? field.Booster : ""));
                                }

                                if (field.SearchType == SearchType.Fuzzy || field.SearchType == SearchType.FuzzyAndWilcard)
                                {
                                    luceneQuery.Append(" (" + FieldCultureName(field.Name) + ": " + term + "~" + field.FuzzyConfiguration + ")" + (!string.IsNullOrEmpty(field.Booster) ? field.Booster : ""));
                                }

                                if (field.SearchType == SearchType.Exact)
                                {
                                    luceneQuery.Append(" (" + FieldCultureName(field.Name) + ": " + term + ") " + (!string.IsNullOrEmpty(field.Booster) ? field.Booster : ""));
                                }

                                luceneQuery.Append(")");
                            }
                            luceneQuery.Append(")");
                        }

                        i++;
                    }

                    IQuery searchQuery = searcher.CreateQuery("content");

                    ((LuceneSearchQueryBase)searchQuery).QueryParser.AllowLeadingWildcard = true;

                    var booleanOperation = searchQuery.NativeQuery(luceneQuery.ToString());

                    var results = _query.Search(booleanOperation, 0, 30, out totalRecords).OrderByDescending(x => x.Score);

                    return results.Select(x => new Umbraco10Content(x));
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to query catalog search service. Query: " + query);
                _logger.LogInformation(luceneQuery.ToString());
            }

            return null;
        }
    }
}
