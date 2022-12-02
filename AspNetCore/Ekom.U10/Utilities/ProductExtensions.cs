using Ekom.Models;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Web.Common;
using Umbraco.Extensions;

namespace EkomCore.U10.Utilities
{
    public static class ProductExtensions
    {
        public static IPublishedContent GetContent(this IProduct content, UmbracoHelper umbHelper, string propertyAlias, string key = null)
        {
            var value = content.GetValue(propertyAlias, key);

            if (!string.IsNullOrEmpty(value) && value.InvariantStartsWith("umb"))
            {

                if (value.InvariantContains("document"))
                {
                    var node = umbHelper.Content(value);

                    if (node != null)
                    {
                        return node;
                    }
                }
                else if (value.InvariantContains("media"))
                {
                    var node = umbHelper.Media(value);

                    if (node != null)
                    {
                        return node;
                    }
                }      
            }

            return null;

        }
        public static IEnumerable<IPublishedContent> GetContents(this IProduct content, UmbracoHelper umbHelper, string propertyAlias, string key = null)
        {
            var value = content.GetValue(propertyAlias, key);

            if (!string.IsNullOrEmpty(value) && value.InvariantStartsWith("umb"))
            {
                var result = new List<IPublishedContent>();

                foreach (var udi in value.Split(','))
                {
                    if (udi.InvariantContains("document"))
                    {
                        var node = umbHelper.Content(udi);

                        if (node != null)
                        {
                            result.Add(node);
                        }
                    } else if (udi.InvariantContains("media"))
                    {
                        var node = umbHelper.Media(udi);

                        if (node != null)
                        {
                            result.Add(node);
                        }
                    }

                }

                return result;
            }

            return Enumerable.Empty<IPublishedContent>();

        }
    }
}
