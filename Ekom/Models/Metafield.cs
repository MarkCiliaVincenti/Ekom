using Ekom;
using Ekom.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EkomCore.Models
{
    public class Metafield
    {
        public Metafield(UmbracoContent x)
        {
            var titleValues = JsonConvert.DeserializeObject<PropertyValue>(x.GetValue("title"));
            var values = x.GetValue("values");

            Id = x.Id;
            Key = x.Key;
            Title = titleValues.Values.ToDictionary(z => z.Key, z => z.Value.ToString());
            Name = x.Name;
            Required = x.Properties.GetPropertyValue("required").ConvertToBool();
            Filterable = x.Properties.GetPropertyValue("filterable").ConvertToBool();
            EnableMultipleChoice = x.Properties.GetPropertyValue("enableMultipleChoice").ConvertToBool();

            if (!string.IsNullOrEmpty(values))
            {

                Values = JsonConvert.DeserializeObject<List<MetafieldValues>>(values);
            }
        }

        public int Id { get; set; }
        public Guid Key { get; set; }
        public string Name { get; set; }
        public Dictionary<string, string> Title { get; set; } = new Dictionary<string, string>();
        public bool Filterable { get; set; }
        public bool EnableMultipleChoice { get; set; }
        public bool Required { get; set; }
        public List<MetafieldValues> Values { get; set; } = new List<MetafieldValues>();
    }

    public class MetafieldValues
    {

        public string Id { get; set; }

        public Dictionary<string, string> Values { get; set; } = new Dictionary<string, string>();
    }
}
