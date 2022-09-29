using Ekom.Models;
using Ekom.Services;
using Ekom.U10.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Umbraco.Cms.Core;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.Web;
using Umbraco.Extensions;

namespace Ekom.U10.Services
{
    class NodeService : INodeService
    {
        readonly ILogger<NodeService> _logger;
        readonly IUmbracoContextFactory _context;
        readonly HttpContext _httpContext;
        public NodeService(
            IUmbracoContextFactory context,
            HttpContext httpContext,
            ILogger<NodeService> logger)
        {
            _context = context;
            _httpContext = httpContext;
            _logger = logger;
        }

        public IEnumerable<UmbracoContent> NodesByTypes(string contentTypeAlias)
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

                return results.Select(x => new Umbraco10Content(x));
            }
        }

        public IEnumerable<UmbracoContent> NodeAncestors(string id)
        {
            var node = GetNodeById(id);

            var ancestors = node.Ancestors().Select(x => new Umbraco10Content(x));

            return ancestors;
        }
        public IEnumerable<UmbracoContent> NodeCatalogAncestors(string id)
        {
            var node = GetNodeById(id);

            var ancestors = node.AncestorsOrSelf().Where(x => x.IsDocumentType("ekmCategory") || x.IsDocumentType("ekmProduct")).Select(x => new Umbraco10Content(x));

            ancestors.Reverse();

            return ancestors;
        }
        public IEnumerable<UmbracoContent> NodeChildren(string id)
        {
            var node = GetNodeById(id);

            var ancestors = node.Children.Select(x => new Umbraco10Content(x));

            return ancestors;
        }

        // <summary>
        // Determine if an<see cref="IContent"/> item is unpublished<para />
        // Traverses up content tree, checking all parents
        // </summary>
        // <returns>True if disabled</returns>
        public bool IsItemUnpublished(UmbracoContent node)
        {
            string path = node.Path;

            foreach (var item in GetAllCatalogAncestors(node))
            {
                // Unpublished items can't be found in the examine index
                if (item == null || !item.IsPublished())
                {
                    return true;
                }
            }

            return false;
        }

        public IEnumerable<UmbracoContent> GetAllCatalogAncestors(UmbracoContent item)
        {
            var node = GetNodeById(item.Id);

            var ancestors = node.AncestorsOrSelf().Where(x => x.IsDocumentType("ekmCategory") || x.IsDocumentType("ekmProduct")).ToList();

            ancestors.Reverse();
            
            return ancestors.Select(x => new Umbraco10Content(x));
        }

        /// <summary>
        /// Get <see cref="IPublishedContent"/> node by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Property Value</returns>
        private IPublishedContent GetNodeById(int id)
        {
            using (var cref = _context.EnsureUmbracoContext())
            {
                var cache = cref.UmbracoContext.Content;

                return cache.GetById(id);
            }
        }

        /// <summary>
        /// Get <see cref="IPublishedContent"/> node by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Property Value</returns>
        private IPublishedContent GetNodeById(string id)
        {
            using (var cref = _context.EnsureUmbracoContext())
            {
                var cache = cref.UmbracoContext.Content;


                if (int.TryParse(id, out int _intId))
                {
                    return cache.GetById(_intId);
                }

                if (Guid.TryParse(id, out Guid _guidId))
                {
                    return cache.GetById(_guidId);
                }
                
                if (UdiParser.TryParse(id, out Udi _udiId))
                {
                    return cache.GetById(_udiId);
                }
            }

            return null;
        }

        /// <summary>
        /// Get <see cref="UmbracoContent"/> node by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Property Value</returns>
        public UmbracoContent NodeById(int id)
        {
            using (var cref = _context.EnsureUmbracoContext())
            {
                var cache = cref.UmbracoContext.Content;

                return cache.GetById(id) as Umbraco10Content;
            }
        }

        /// <summary>
        /// Get <see cref="UmbracoContent"/> node by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Property Value</returns>
        public UmbracoContent NodeById(Guid id)
        {
            using (var cref = _context.EnsureUmbracoContext())
            {
                var cache = cref.UmbracoContext.Content;

                return cache.GetById(id) as Umbraco10Content;
            }
        }


        /// <summary>
        /// Get <see cref="UmbracoContent"/> node by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Property Value</returns>
        public UmbracoContent NodeById(Udi id)
        {
            using (var cref = _context.EnsureUmbracoContext())
            {
                var cache = cref.UmbracoContext.Content;

                return cache.GetById(id) as Umbraco10Content;
            }
        }

        /// <summary>
        /// Get <see cref="UmbracoContent"/> node by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Property Value</returns>
        public UmbracoContent NodeById(string id)
        {

            if (int.TryParse(id, out int _intId))
            {
                return NodeById(_intId);
            }

            if (Guid.TryParse(id, out Guid _guidId))
            {
                return NodeById(_guidId);
            }

            if (UdiParser.TryParse(id, out Udi _udiId))
            {
                return NodeById(_udiId);
            }

            return null;
        }

        /// <summary>
        /// Get <see cref="UmbracoContent"/> media by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Property Value</returns>
        public UmbracoContent MediaById(int id)
        {
            using (var cref = _context.EnsureUmbracoContext())
            {
                var cache = cref.UmbracoContext.Media;

                return cache.GetById(id) as Umbraco10Content;
            }
        }

        /// <summary>
        /// Get <see cref="UmbracoContent"/> media by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Property Value</returns>
        public UmbracoContent MediaById(Guid id)
        {
            using (var cref = _context.EnsureUmbracoContext())
            {
                var cache = cref.UmbracoContext.Media;

                return cache.GetById(id) as Umbraco10Content;
            }
        }


        /// <summary>
        /// Get <see cref="UmbracoContent"/> media by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Property Value</returns>
        public UmbracoContent MediaById(Udi id)
        {
            using (var cref = _context.EnsureUmbracoContext())
            {
                var cache = cref.UmbracoContext.Media;

                return cache.GetById(id) as Umbraco10Content;
            }
        }

        /// <summary>
        /// Get <see cref="UmbracoContent"/> media by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Property Value</returns>
        public UmbracoContent MediaById(string id)
        {

            if (int.TryParse(id, out int _intId))
            {
                return MediaById(_intId);
            }

            if (Guid.TryParse(id, out Guid _guidId))
            {
                return MediaById(_guidId);
            }

            if (UdiParser.TryParse(id, out Udi _udiId))
            {
                return MediaById(_udiId);
            }

            return null;
        }

        /// <summary>
        /// Get <see cref="IPublishedContent"/> media by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Property Value</returns>
        private IPublishedContent GetMediaById(string id)
        {
            using (var cref = _context.EnsureUmbracoContext())
            {
                var cache = cref.UmbracoContext.Media;


                if (int.TryParse(id, out int _intId))
                {
                    return cache.GetById(_intId);
                }

                if (Guid.TryParse(id, out Guid _guidId))
                {
                    return cache.GetById(_guidId);
                }

                if (UdiParser.TryParse(id, out Udi _udiId))
                {
                    return cache.GetById(_udiId);
                }
            }

            return null;
        }


        public string GetUrl(string id)
        {
            var node = GetNodeById(id);

            if (node == null)
            {
                node = GetMediaById(id);
            }

            using (var cref = _context.EnsureUmbracoContext())
            {
                return cref.UmbracoContext.Content.GetById(node.Id).Url();
            }
        }


    }
}
