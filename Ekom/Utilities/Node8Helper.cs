using Ekom.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Core;
using Umbraco.Core.Composing;
using Umbraco.Core.Models;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;

namespace Ekom.Utilities
{
    public class Node8Helper
    {
        public static Node8Helper Instance => Current.Factory.GetInstance<Node8Helper>();

        private readonly IUmbracoContextFactory _context;
        public Node8Helper(IUmbracoContextFactory context)
        {

            _context = context;
        }

        /// <summary>
        /// Get <see cref="IPublishedContent"/> node by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Property Value</returns>
        public IPublishedContent GetNodeById(int id)
        {
            using (var cref = _context.EnsureUmbracoContext())
            {
                var cache = cref.UmbracoContext.Content;

                return cache.GetById(id);
            }
        }

        /// <summary>
        /// Get <see cref="IPublishedContent"/> node by Udi
        /// </summary>
        /// <param name="udi"></param>
        /// <returns>Property Value</returns>
        public IPublishedContent GetNodeByUdi(string udi)
        {
            if (!string.IsNullOrEmpty(udi))
            {

                if (Udi.TryParse(udi, out Udi id))
                {
                    using (var cref = _context.EnsureUmbracoContext())
                    {
                        var cache = cref.UmbracoContext.Content;

                        return cache.GetById(id);
                    }
                }
            }

            return null;
        }
        public List<IPublishedContent> GetAllCatalogAncestors(IContent item)
        {
            var node = GetNodeById(item.Id);

            var ancestors = node.AncestorsOrSelf().Where(x => x.IsDocumentType("ekmCategory") || x.IsDocumentType("ekmProduct")).ToList();

            ancestors.Reverse();

            return ancestors;
        }

        public List<IPublishedContent> GetAllCatalogAncestors(IPublishedContent node)
        {
            var ancestors = node.AncestorsOrSelf().Where(x => x.IsDocumentType("ekmCategory") || x.IsDocumentType("ekmProduct")).ToList();

            ancestors.Reverse();

            return ancestors;
        }

    }
}
