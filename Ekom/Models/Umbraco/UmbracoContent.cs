using System;
using System.Collections.Generic;

namespace Ekom.Core.Models
{
    public class UmbracoContent
    {
        public UmbracoContent(Dictionary<string, string> defaultProperties, Dictionary<string, string> contentProperies)
        {
            Properties = defaultProperties;

            foreach (var prop in contentProperies)
            {
                Properties.Add(prop.Key, prop.Value);
            }

            Id = Convert.ToInt32(Properties.GetPropertyValue("id"));
            Key = new Guid(Properties.GetPropertyValue("__Key"));
            // Add culture parameter to get the correct nodename based on language ?
            Name = Properties.GetPropertyValue("nodeName");
        }

        /// <summary>
        /// All node properties
        /// </summary>
        public Dictionary<string, string> Properties = new Dictionary<string, string>();

        public int Id { get; set; }
        public Guid Key { get; set; }
        // Used for MEdia Url. Think we should remove this for simplicity and get the url specificly. Used in the Image class
        public string Url { get; set; }
        public string Name { get; set; }
    }
}
