using Umbraco.Cms.Core.IO;
using Umbraco.Cms.Core.PropertyEditors;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Core.WebAssets;
using Umbraco.Cms.Infrastructure.WebAssets;

namespace Ekom.U10.DataEditors
{
    [DataEditor(
    "Ekom.Property",
    EditorType.PropertyValue,
    "Ekom Property Editor",
    "/App_Plugins/Ekom/DataTypes/PropertyEditor/views/ekmPropertyEditor.html",
    ValueType = ValueTypes.Json,
    HideLabel = true)]
    [PropertyEditorAsset(AssetType.Javascript, "/App_Plugins/Ekom/DataTypes/PropertyEditor/js/ekmPropertyEditor.controller.js")]
    public class EkomPropertyEditor : DataEditor
    {
        private readonly IIOHelper _ioHelper;
        private readonly IEditorConfigurationParser _editorConfigurationParser;

        public EkomPropertyEditor(
            IDataValueEditorFactory dataValueEditorFactory,
            IIOHelper ioHelper,
            IEditorConfigurationParser editorConfigurationParser,
            EditorType type = EditorType.PropertyValue)
            : base(dataValueEditorFactory, type)
        {
            _editorConfigurationParser = editorConfigurationParser;
            _ioHelper = ioHelper;
        }

        protected override IConfigurationEditor CreateConfigurationEditor() => new EkomPropertyEditorConfigurationEditor(_ioHelper, _editorConfigurationParser);
    }

    public class EkomPropertyEditorConfigurationEditor : ConfigurationEditor<EkomPropertyEditorConfiguration>
    {
        public EkomPropertyEditorConfigurationEditor(IIOHelper ioHelper, IEditorConfigurationParser editorConfigurationParser) : base(ioHelper, editorConfigurationParser)
        {
        }
    }

    public class EkomPropertyEditorConfiguration
    {
        [ConfigurationField(
            "dataType", 
            "Data Type",
            "/App_Plugins/Ekom/DataTypes/PropertyEditor/views/ekmPropertyEditorPicker.html",
            Description =
                "Select the data type to wrap.")]
        public object DataType { get; set; }


        [ConfigurationField(
        "useStores",
        "Use Stores",
        "boolean",
        Description =
            "Defaults on Languages, select this to use Stores instead")]
        public bool useStores { get; set; }
    }
}
