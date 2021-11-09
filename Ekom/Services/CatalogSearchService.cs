using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Web;
using Umbraco.Web.Composing;
using Umbraco.Core.Logging;
using System.Globalization;
using Umbraco.Core.Models.PublishedContent;
using Examine;
using Umbraco.Examine;
using Examine.LuceneEngine.Providers;
using Lucene.Net.QueryParsers;
using Umbraco.Core;
using Examine.Search;
using Examine.LuceneEngine.Search;

namespace Ekom.Services
{
    public class CatalogSearchService
    {
        private readonly ILogger _logger;
        private readonly IPublishedContentQuery _query;
        public CatalogSearchService(IPublishedContentQuery query, ILogger logger)
        {
            _logger = logger;
            _query = query;
        }
        public static CatalogSearchService Instance => Umbraco.Core.Composing.Current.Factory.GetInstance<CatalogSearchService>();

        public IEnumerable<PublishedSearchResult> QueryCatalog(string query, out long totalRecords)
        {
            totalRecords = 0;

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
                        Booster = "^3.0"
                    },
                    new SearchField()
                    {
                        Name = "title",
                        Booster = "^2.0"
                    },
                    new SearchField()
                    {
                        Name = "description",
                        Booster = "^1.0",
                        SearchType = SearchType.Fuzzy
                    }
                };

                var searcher = (BaseLuceneSearcher)index.GetSearcher();

                var luceneQuery = new StringBuilder();

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

                    if (fields == null || string.IsNullOrEmpty(queryWithOutStopWords))
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
                            luceneQuery.Append(")");
                        }
                        luceneQuery.Append(")");
                    }

                    i++;
                }

                IQuery searchQuery = searcher.CreateQuery("content");

                ((LuceneSearchQueryBase)searchQuery).QueryParser.AllowLeadingWildcard = true;

                var booleanOperation = searchQuery
                .NativeQuery(luceneQuery.ToString());

                    booleanOperation = booleanOperation.And().GroupedOr(new string[1] {
                        "__NodeTypeAlias"
                    }, new string[] { "ekmProduct", "ekmCategory" });
                

                var results = _query.Search(booleanOperation, 0, 30, out totalRecords).OrderByDescending(x => x.Score);

                return results;

            }

            return null;
        }

        private string RemoveDiacritics(string text)
        {
            foreach (var characterMap in Characters)
            {
                text = text.Replace(characterMap.Key, characterMap.Value);
            }

            var normalizedString = text.Normalize(NormalizationForm.FormD);
            var stringBuilder = new StringBuilder();

            foreach (var c in normalizedString)
            {
                var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
                if (unicodeCategory != UnicodeCategory.NonSpacingMark)
                {
                    stringBuilder.Append(c);
                }
            }

            return stringBuilder.ToString().Normalize(NormalizationForm.FormC);
        }

        private Dictionary<string, string> Characters = new Dictionary<string, string>
        {
            { "æ", "ae" },
            { "ð", "d" },
            { "þ", "th" },
            { "%", "" },
            { ";", "" },
            { "!", "" },
            { ",", "" },
            { "'", "" },
            { ".", "" },
            { "&", "" },
        };
        public class SearchField
        {
            public string Name { get; set; }
            public SearchType SearchType { get; set; } = SearchType.FuzzyAndWilcard;
            public string FuzzyConfiguration { get; set; } = "0.5";
            public string Booster { get; set; }
        }
        public enum SearchType
        {
            Exact,
            Wildcard,
            Fuzzy,
            FuzzyAndWilcard
        }
        public string FieldCultureName(string fieldName, string culture = null)
        {
            return string.IsNullOrEmpty(culture) ? fieldName : fieldName + "_" + culture.ToLowerInvariant();
        }
    }
}
