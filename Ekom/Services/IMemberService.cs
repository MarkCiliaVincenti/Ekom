using Ekom.Models;
using System.Collections.Generic;

namespace Ekom.Services
{
    interface IMemberService
    {
        UmbracoMember GetByUsername(string t);
        void Save(Dictionary<string, object> t, UmbracoMember member);
        void Save(Dictionary<string, object> t, string userSsn);
    }
}
