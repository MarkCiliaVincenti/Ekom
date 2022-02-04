using Ekom.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Web;

namespace Ekom.U8.Services
{
    class NodeService : INodeService
    {
        protected readonly IUmbracoContextFactory _context;
        public NodeService(IUmbracoContextFactory context)
        {
            _context = context;
        }

        public IEnumerable<object> NodesByTypes(string contentTypeAlias)
        {
            using (var cref = _context.EnsureUmbracoContext())
            {
                var cache = cref.UmbracoContext.Content;
                var ekomRoot = cache.GetAtRoot().FirstOrDefault(x => x.IsDocumentType("ekom"));

                if (ekomRoot == null)
                {
                    throw new Exception("Ekom root node not found.");
                }

                var results = ekomRoot.DescendantsOfType(contentTypeAlias).ToList();

                return results;
            }
        }
    }
}
