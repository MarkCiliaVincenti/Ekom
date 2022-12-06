using Ekom;
using Ekom.Models;
using System;
using System.Collections.Generic;

namespace EkomCore.Models
{
    public class Metafield
    {
        public Metafield(UmbracoContent x)
        {
            Id = x.Id;
            Key = x.Key;
            Title = x.Properties.GetPropertyValue("title");
            Name = x.Name;
            Filterable = x.Properties.GetPropertyValue("filterable").ConvertToBool();
            EnableMultipleChoice = x.Properties.GetPropertyValue("enableMultipleChoice").ConvertToBool();
        }

        public int Id { get; set; }
        public Guid Key { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public bool Filterable { get; set; }
        public bool EnableMultipleChoice { get; set; }
        public List<string> Values { get; set; } = new List<string>();
    }
}
