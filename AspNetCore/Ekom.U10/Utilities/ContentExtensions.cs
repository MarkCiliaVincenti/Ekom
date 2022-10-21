using Ekom;
using Ekom.Models;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Umbraco.Cms.Core.Models;
using Umbraco.Cms.Core.Services;

namespace EkomCore.U10.Utilities
{
    public static class ContentExtensions
    {
        public static void SetProperty(this IContent content, string alias, Dictionary<string, object> items, PropertyEditorType type)
        {

            if (content == null)
            {
                throw new ArgumentNullException("content");
            }

            if (string.IsNullOrEmpty(alias))
            {
                throw new ArgumentNullException("alias");
            }

            if (content == items)
            {
                throw new ArgumentNullException("items");
            }

            var property = content.Properties.FirstOrDefault(x => x.Alias.ToUpperInvariant() == alias.ToUpperInvariant());

            if (property != null)
            {
                var dts = Configuration.Resolver.GetService<IDataTypeService>();

                IEnumerable<IDataType> byEditorAlias = dts.GetByEditorAlias(property.PropertyType.PropertyEditorAlias);
                if (byEditorAlias.Any())
                {
                    IDataType dataType = byEditorAlias.FirstOrDefault();
                    string value = JsonConvert.SerializeObject(new PropertyValue
                    {
                        DtdGuid = dataType.Key,
                        Values = items,
                        Type = type.ToString()
                    });
                    content.SetValue(alias, value);
                    return;
                }

                throw new InvalidOperationException("Unable to get data type for property.");
            }
        }
        public static void SetProperty(this IContent content, string alias, object value, string culture = null)
        {
            content.SetValue(alias, value, culture);
        }

     }
}
