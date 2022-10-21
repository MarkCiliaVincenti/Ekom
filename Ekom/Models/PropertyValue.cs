using System;
using System.Collections.Generic;

namespace Ekom.Models
{
    internal class PropertyValue
    {
        public Guid DtdGuid { get; set; }
        public IDictionary<string, object> Values = new Dictionary<string, object>();
        public string Type {get; set;}
    }
}
