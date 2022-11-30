using Ekom.Services;
using EkomCore.Models;
using System.Collections.Generic;
using System.Linq;

namespace EkomCore.Services
{
    class MetafieldService : IMetafieldService
    {
        private readonly INodeService _nodeService;
        public MetafieldService(INodeService nodeService)
        {
            _nodeService = nodeService;
        }

        public IEnumerable<Metafield> GetMetafields()
        {
            var metafieldNodes = _nodeService.NodesByTypes("ekmMetaField");

            return metafieldNodes.Select(x => new Metafield(x));
        }
    }
}
