using Ekom.Core.Models;
using System;
using System.Collections.Generic;

namespace Ekom.Services
{
    interface INodeService
    {
        IEnumerable<UmbracoContent> NodesByTypes(string contentTypeAlias); 
        bool IsItemUnpublished(UmbracoContent content);
        object NodeById<T>(string t);
        object NodeById<T>(Guid t);
        object NodeById<T>(int t);
        object MediaById<T>(string t);
        object MediaById<T>(Guid t);
        object MediaById<T>(int t);
    }
}
