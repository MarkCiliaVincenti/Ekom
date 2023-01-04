using System.Collections.Generic;

namespace Ekom.Models
{
    public class ProductQuery
    {
        public Dictionary<string, List<string>> Filters { get; set; }
        public int? Page { get; set; }
        public int? PageSize { get; set; }
    }
}
