using Ekom.Models.Abstractions;
using Examine;
using Examine.SearchCriteria;
using System;
using System.Linq;

namespace Ekom.Services
{
    /// <summary>
    /// Unused as service currently
    /// </summary>
    class ExamineService
    {
        public static DateTime ConvertToDatetime(string value)
        {
            return DateTime.ParseExact(value, "yyyyMMddHHmmssfff", System.Globalization.CultureInfo.InvariantCulture);
        }

        Configuration _config;
        ExamineManagerBase _examineMgr;
        public ExamineService(Configuration config, ExamineManagerBase examineMgr)
        {
            _config = config;
            _examineMgr = examineMgr;
        }

        public ISearchResult GetExamineNode(int Id)
        {
            var searcher = _examineMgr.SearchProviderCollection[_config.ExamineSearcher];

            if (searcher != null)
            {
                ISearchCriteria searchCriteria = searcher.CreateSearchCriteria();
                var query = searchCriteria.Id(Id);
                var results = searcher.Search(query.Compile());

                return results.First();
            }

            return null;
        }
    }
}
