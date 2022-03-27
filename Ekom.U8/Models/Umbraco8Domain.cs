using Ekom.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Core.Models;
using Umbraco.Core.Models.PublishedContent;

namespace Ekom.U8.Models
{
    public class Umbraco8Domain : Core.Models.UmbracoDomain
    {
        public Umbraco8Domain(IDomain domain)
            : base(new Dictionary<string, string>
            {
                { "DomainName", domain.DomainName },
                { "Key", domain.Key.ToString() },
                { "LanguageIsoCode", domain.LanguageIsoCode },
                { "Id", domain.Id.ToString() },
                { "RootContentId", domain.RootContentId.HasValue ? domain.RootContentId.Value.ToString() : "" }
            })
        { }
    }
}
