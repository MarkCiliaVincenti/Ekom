using System.Collections.Generic;
using System.Web;

namespace Ekom.Models
{
    public class ProductQuery
    {
        public ProductQuery()
        {
            
        }
        public Dictionary<string, List<string>> Filters { get; set; }
        public int? Page { get; set; }
        public int? PageSize { get; set; }
    }
}
