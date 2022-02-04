using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ekom.Services
{
    /// <summary>
    /// ToDo: Gæti séð fyrir mér að við skiptum upp í UmbracContext services (gamla ApplicationContext daemid, umbraco db köll ofl), 
    /// HttpContext scoped service (Umbraco helper stuff) 
    /// og kannski eitthvað meira session scoped fyrir methoda sem vilja uppl. um current member ?
    /// </summary>
    interface INodeService
    {
        IEnumerable<object> NodesByTypes(string contentTypeAlias);

    }
}
