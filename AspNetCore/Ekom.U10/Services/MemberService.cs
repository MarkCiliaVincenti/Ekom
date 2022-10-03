using Ekom.Models;
using Ekom.U10.Models;
using System.Collections.Generic;
using Umbraco.Cms.Core.Models;
using Umbraco.Cms.Core.Models.Membership;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.Security;

namespace Ekom.U10.Services
{
    class MemberService : Ekom.Services.IMemberService
    {
        private readonly Umbraco.Cms.Core.Services.IMemberService _ms;
        private readonly IMemberManager _memberManager;
        public MemberService(Umbraco.Cms.Core.Services.IMemberService ms, IMemberManager memberManager)
        {
            _ms = ms;
            _memberManager = memberManager;
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

        public async Task<UmbracoMember> GetCurrentMemberAsync()
        {
            var m = await _memberManager.GetCurrentMemberAsync().ConfigureAwait(false);
            IMember? member = _ms.GetById(Convert.ToInt32(m.Id));
            if (member == null)
            {
                return null;
            }
            return new Umbraco10Member(member);
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
