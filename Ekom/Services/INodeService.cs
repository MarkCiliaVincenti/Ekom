using System;
using System.Collections.Generic;

namespace Ekom.Services
{
    interface INodeService
    {
        IEnumerable<object> NodesByTypes(string contentTypeAlias); 
        object NodeById<T>(string t);
        object NodeById<T>(Guid t);
        object NodeById<T>(int t);
        object MediaById<T>(string t);
        object MediaById<T>(Guid t);
        object MediaById<T>(int t);
    }
}
