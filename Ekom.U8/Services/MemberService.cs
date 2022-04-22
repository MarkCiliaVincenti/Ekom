using Ekom.Core.Models;
using Ekom.U8.Models;
using System.Collections.Generic;

namespace Ekom.U8.Services
{
    class MemberService : Core.Services.IMemberService
    {
        private readonly Umbraco.Core.Services.IMemberService _ms;
        MemberService(Umbraco.Core.Services.IMemberService ms) {
            _ms = ms;
        }

        public UmbracoMember GetByUsername(string userName)
        {
            var m = _ms.GetByUsername(userName);

            if (m == null)
            {
                return null;
            }

            return new Umbraco8Member(m);
        }

        public void Save(Dictionary<string, object> data, UmbracoMember member)
        {
            Save(data,member);
        }

        public void Save(Dictionary<string, object> data, string userName)
        {
            var m = _ms.GetByUsername(userName);

            if (m == null)
            {
                return;
            }

            foreach (var d in data)
            {
                if (m.HasProperty(d.Key))
                {
                    m.SetValue(d.Key, d.Value);
                }
                
            }

            _ms.Save(m);
           
        }
    }
}
