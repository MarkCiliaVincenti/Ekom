using Ekom.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ekom.Core.Services
{
    interface IUrlService
    {
        IEnumerable<string> BuildCategoryUrls(List<UmbracoContent> items, IStore store);
        IEnumerable<string> BuildCategoryUrls(string slug, List<string> hierarchy, IStore store);
        IEnumerable<string> BuildProductUrls(string slug, IEnumerable<ICategory> categories, IStore store);
        string GetDomainPrefix(string url);
        string GetNodeEntityUrl(INodeEntityWithUrl node);
    }
}