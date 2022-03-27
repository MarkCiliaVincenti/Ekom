using Ekom.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Core.Models.PublishedContent;

namespace Ekom.U8.Models
{
    public class Umbraco8Content : UmbracoContent
    {
        public Umbraco8Content(IPublishedContent content)
            : base(new Dictionary<string, string>
            {
                { "id", content.Id.ToString() },
                { "__Key", content.Key.ToString() },
                { "nodeName", content.Name },
                { "ContentTypeAlias", content.ContentType.Alias }
            },
            content.Properties.ToDictionary(
                x => x.Alias, 
                x => x.GetValue().ToString()))
        { }
    }
}
