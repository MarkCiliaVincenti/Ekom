using Ekom.Core.Models;
using System.Collections.Generic;
using System.Linq;
using Umbraco.Core.Models;

namespace Ekom.U8.Models
{
    public class Umbraco8Member : UmbracoMember
    {
        public Umbraco8Member(IMember member)
            : base(new Dictionary<string, string>
            {
                { "id", member.Id.ToString() },
                { "__Key", member.Key.ToString() },
                { "nodeName", member.Name },
                { "userName", member.Username }
            },
            member.Properties.ToDictionary(
                x => x.Alias, 
                x => x.GetValue().ToString()))
        { }
    }
}
