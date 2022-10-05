using System.Net;
using Umbraco.Cms.Core.Models;
using Umbraco.Cms.Core.PropertyEditors;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Web.BackOffice.Controllers;

namespace Ekom.U10.Controllers
{
    public class EkomBackofficeApiController : UmbracoAuthorizedApiController
    {
        private readonly IDataTypeService _dts;
        private readonly PropertyEditorCollection _propertyEditorCollection;
        private readonly ILocalizationService _localizationService;
        private readonly IMemberTypeService _memberTypeService;
        private readonly IContentTypeService _contentTypeService;

        public EkomBackofficeApiController(
            IDataTypeService dts,
            PropertyEditorCollection propertyEditorCollection,
            ILocalizationService localizationService,
            IMemberTypeService memberTypeService,
            IContentTypeService contentTypeService
            )
        {
            _dts = dts;
            _propertyEditorCollection = propertyEditorCollection;
            _localizationService = localizationService;
            _memberTypeService = memberTypeService;
            _contentTypeService = contentTypeService;
        }

        public IEnumerable<object> GetNonEkomDataTypes()
        {
            return _dts.GetAll()
                .Where(x => !x.EditorAlias.StartsWith("Ekom"))
                .OrderBy(x => x.SortOrder)
                .Select(x => new
                {
                    guid = x.Key,
                    name = x.Name,
                    editorAlias = x.EditorAlias
                });
        }

        public object GetDataTypeById(Guid id)
        {
            var dtd = _dts.GetDataType(id);
            return FormatDataType(dtd);
        }

        public object GetDataTypeByAlias(
            string contentTypeAlias,
            string propertyAlias)
        {

            var ct = _contentTypeService.Get(contentTypeAlias);

            var prop = ct?.CompositionPropertyTypes.FirstOrDefault(x => x.Alias == propertyAlias);
            
            if (prop == null)
            {
                throw new Exceptions.HttpResponseException(HttpStatusCode.NotFound);
            }

            var dtd = _dts.GetDataType(prop.DataTypeKey);
            return FormatDataType(dtd);
        }

        public IEnumerable<object> GetLanguages()
        {
            var languages = _localizationService.GetAllLanguages();

            return languages;
        }

        public IEnumerable<object> GetStores()
        {
            var stores = API.Store.Instance.GetAllStores();

            return stores;
        }

        protected object FormatDataType(IDataType dtd)
        {
            if (dtd == null)
                throw new Exceptions.HttpResponseException(HttpStatusCode.NotFound);

            var propertyEditor = _propertyEditorCollection.FirstOrDefault(x => x.Alias == dtd.EditorAlias);

            var preValues = dtd.Configuration;

            return new
            {
                guid = dtd.Key,
                propertyEditorAlias = dtd.EditorAlias,
                preValues = preValues,
                view = propertyEditor.GetValueEditor(null).View
            };
        }
    }
}
