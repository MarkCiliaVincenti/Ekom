using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ekom.Models
{
    internal class PropertyValue
    {
        public IDictionary<string, object> Values = new Dictionary<string, object>();
        public string Type {get; set;}
    }
}
