using Ekom.Models;
using Ekom.Umb.Services;
using Microsoft.Extensions.DependencyInjection;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Extensions;

namespace Ekom
{
    public static class NodeEntitiyExtensions
    {

        public static T GetValue<T>(this IProduct node, string propAlias, string alias = null)
        {
            string val = node.GetValue(propAlias, alias);

            if (typeof(T) == typeof(string))
            {
                return (T)(object)val;
            }
            if (typeof(T) == typeof(int))
            {
                return (T)(object)Convert.ToInt32(val);
            }
            if (typeof(T) == typeof(bool))
            {
                return (T)(object)val.IsBoolean();
            }
            if (typeof(T) == typeof(IPublishedContent))
            {
                return (T)(object)GetContent(val);
            }
            if (typeof(T) == typeof(IEnumerable<IPublishedContent>))
            {
                return (T)(object)GetContents(val);
            }

            return (T)(object)val;
        }

        public static T GetValue<T>(this ICategory node, string propAlias, string alias = null)
        {
            string val = node.GetValue(propAlias, alias);

            if (typeof(T) == typeof(string))
            {
                return (T)(object)val;
            }
            if (typeof(T) == typeof(int))
            {
                return (T)(object)Convert.ToInt32(val);
            }
            if (typeof(T) == typeof(bool))
            {
                return (T)(object)val.IsBoolean();
            }
            if (typeof(T) == typeof(IPublishedContent))
            {
                return (T)(object)GetContent(val);
            }
            if (typeof(T) == typeof(IEnumerable<IPublishedContent>))
            {
                return (T)(object)GetContents(val);
            }

            return (T)(object)val;
        }

        public static T GetValue<T>(this INodeEntity node, string propAlias, string alias = null)
        {
            string val = node.GetValue(propAlias, alias);

            if (typeof(T) == typeof(string))
            {
                return (T)(object)val;
            }
            if (typeof(T) == typeof(int))
            {
                return (T)(object)Convert.ToInt32(val);
            }
            if (typeof(T) == typeof(bool))
            {
                return (T)(object)val.IsBoolean();
            }
            if (typeof(T) == typeof(IPublishedContent))
            {
                return (T)(object)GetContent(val);
            }
            if (typeof(T) == typeof(IEnumerable<IPublishedContent>))
            {
                return (T)(object)GetContents(val);
            }

            return (T)(object)val;
        }

        private static IPublishedContent GetContent(string value)
        {

            if (!string.IsNullOrEmpty(value) && value.InvariantStartsWith("umb"))
            {
                var r = Configuration.Resolver.GetService<NodeService>();

                if (value.InvariantContains("document"))
                {
                    var node = r.GetNodeById(value);

                    if (node != null)
                    {
                        return node;
                    }
                }
                else if (value.InvariantContains("media"))
                {
                    var node = r.GetMediaById(value);

                    if (node != null)
                    {
                        return node;
                    }
                }
            }

            return null;

        }
        private static IEnumerable<IPublishedContent> GetContents(string value)
        {
            if (!string.IsNullOrEmpty(value) && value.InvariantStartsWith("umb"))
            {
                var r = Configuration.Resolver.GetService<NodeService>();

                var result = new List<IPublishedContent>();

                foreach (var udi in value.Split(','))
                {
                    if (udi.InvariantContains("document"))
                    {
                        var node = r.GetNodeById(udi);

                        if (node != null)
                        {
                            result.Add(node);
                        }
                    }
                    else if (udi.InvariantContains("media"))
                    {
                        var node = r.GetMediaById(udi);

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
