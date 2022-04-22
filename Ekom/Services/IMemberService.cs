using Ekom.Core.Models;
using System.Collections.Generic;

namespace Ekom.Core.Services
{
    interface IMemberService
    {
        UmbracoMember GetByUsername(string t);
        void Save(Dictionary<string,object> t, UmbracoMember member);
        void Save(Dictionary<string, object> t, string userSsn);
    }
}
