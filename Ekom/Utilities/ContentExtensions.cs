using Ekom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ekom.Utilities
{
    public static class ContentExtensions
    {
        /// <summary>
        /// Retrieve a store specific property <para/>
        /// </summary>
        /// <param name="item"></param>
        /// <param name="field">Umbraco Alias</param>
        /// <param name="storeAlias"></param>
        /// <returns>Property Value</returns>
        public static string GetStoreProperty(this UmbracoContent item, string field, string storeAlias)
        {
            if (item.Properties.ContainsKey(field))
            {
                var fieldValue = item.Properties.GetPropertyValue(field, storeAlias);

                return fieldValue;
            }

            return string.Empty;
        }


        /// <summary>
        /// Determine if an examine item is disabled/unpublished <para />
        /// Traverses up content tree, checking all parents, looks for Umbraco properties matching stores country code
        /// </summary>
        /// <param name="searchResult"></param>
        /// <param name="store">Used to look for umbraco properties matching stores country code </param>
        /// <param name="path"></param>
        /// <param name="allCatalogItems"></param>
        /// <returns>True if disabled</returns>
        public static bool IsItemDisabled(
            this UmbracoContent item,
            IStore store,
            IEnumerable<UmbracoContent> ancestors
            )
        {
            var selfDisableField = GetStoreProperty(item, "disable", store.Alias);

            if (!string.IsNullOrEmpty(selfDisableField))
            {
                if (selfDisableField.ConvertToBool())
                {
                    return true;
                }
            }

            var catalogAncestors = ancestors.Where(x => x.IsDocumentType("ekmCategory") || x.IsDocumentType("ekmProduct")).ToList();

            foreach (var ancestor in catalogAncestors)
            {
                if (ancestor != null)
                {
                    var disableField = GetStoreProperty(ancestor, "disable", store.Alias);

                    if (!string.IsNullOrEmpty(disableField))
                    {
                        return disableField.ConvertToBool();
                    }
                }
                else
                {
                    return true;
                }
            }

            return false;
        }
    }
}
