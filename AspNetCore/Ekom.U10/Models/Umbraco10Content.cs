using Ekom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Cms.Core.Models;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace Ekom.U10.Models
{
    class Umbraco10Content : UmbracoContent
    {
        public Umbraco10Content(IPublishedContent content)
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

        public Umbraco10Content(IContent content)
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

        public Umbraco10Content(PublishedSearchResult content)
            : base(new Dictionary<string, string>
            {
                { "id", content.Content.Id.ToString() },
                { "__Key", content.Content.Key.ToString() },
                { "nodeName", content.Content.Name },
                { "ContentTypeAlias", content.Content.ContentType.Alias }
            },
            content.Content.Properties.ToDictionary(
                x => x.Alias,
                x => x.GetValue().ToString()))
        { }
    }
}
