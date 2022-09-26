using Ekom.Models;
using Ekom.Services;
using Ekom.U10.Models;
using Ekom.Utilities;
using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Web.Common;
using Umbraco.Extensions;

namespace Ekom.U10.Services
{
    class UmbracoService : IUmbracoService
    {
        private readonly IDataTypeService _dataTypeService;
        private readonly IDomainService _domainService;
        private readonly UmbracoHelper _umbracoHelper;
        public UmbracoService(
            IDomainService domainService,
            IDataTypeService dataTypeService,
            UmbracoHelper umbracoHelper
        )
        {
            _domainService = domainService;
            _dataTypeService = dataTypeService;
            _umbracoHelper = umbracoHelper;
        }

        public string GetDictionaryValue(string key)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UmbracoDomain> GetDomains(bool includeWildcards = false)
        {
            return _domainService.GetAll(includeWildcards).Select(x => new Umbraco10Domain(x));
        }
        public string GetDataType(string typeValue)
        {

            if (int.TryParse(typeValue, out int typeValueInt))
            {
                var dt = _dataTypeService.GetDataType(typeValueInt);

                // FIX: verify
                typeValue = dt.ConfigurationAs<string>();
            }
            typeValue = typeValue.Contains('[') ? JsonConvert.DeserializeObject<string[]>(typeValue).FirstOrDefault() : typeValue;
            return typeValue;
        }
        public IEnumerable<string> GetContent(string guid)
        {
            var nodes = guid
                    ?.Split(',')
                    .Where(x => !string.IsNullOrEmpty(x))
                    .Select(x => _umbracoHelper.Content(GuidUdiHelper.GetGuid(x)))
                    .Where(x => x != null)
                    .ToList();
            return nodes.Select(x => x.Id.ToString());
        }
    }
}
