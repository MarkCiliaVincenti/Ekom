using Ekom.Models;
using Ekom.U10.Models;
using System.Collections.Generic;

namespace Ekom.U10.Services
{
    class MemberService : Ekom.Services.IMemberService
    {
        private readonly Umbraco.Cms.Core.Services.IMemberService _ms;
        MemberService(Umbraco.Cms.Core.Services.IMemberService ms) {
            _ms = ms;
        }

        public UmbracoMember GetByUsername(string userName)
        {
            var m = _ms.GetByUsername(userName);

            if (m == null)
            {
                return null;
            }

            return new Umbraco10Member(m);
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
