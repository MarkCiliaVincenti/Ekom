using System.Collections.Generic;
using System.Linq;

namespace Ekom
{
    public static class DictionaryExtensions
    {
        /// <summary>
        /// Get value from umbraco properties by store
        /// Retrieves a store specific property <para/>
        /// alias name = field + "_" + storeAlias <para/>
        /// f.x. disabled_IS
        /// </summary>
        public static string GetPropertyValue(this Dictionary<string, string> properties, string propertyAlias, string storeAlias = null, string language = null)
        {
            return GetBasePropertyValue(properties, propertyAlias, storeAlias, language);
        }

        /// <summary>
        /// Get value from umbraco properties by store
        /// Retrieves a store specific property <para/>
        /// alias name = field + "_" + storeAlias <para/>
        /// f.x. disabled_IS
        /// </summary>
        public static string GetPropertyValue(this IReadOnlyDictionary<string, string> properties, string propertyAlias, string storeAlias = null, string language = null)
        {
            return GetBasePropertyValue(properties.ToDictionary(kvp => kvp.Key, kvp => kvp.Value), propertyAlias, storeAlias, language);
        }

        private static string GetBasePropertyValue(Dictionary<string, string> properties, string propertyAlias, string storeAlias = null, string language = null)
        {
            string val = string.Empty;

            if (!string.IsNullOrEmpty(language))
            {
                propertyAlias = propertyAlias + "_" + language.ToLowerInvariant();
            }

            if (!string.IsNullOrEmpty(propertyAlias))
            {
                properties.TryGetValue(propertyAlias, out val);
            }

            if (!string.IsNullOrEmpty(storeAlias))
            {
                return val.GetVortoValue(storeAlias) ?? string.Empty;
            }
            else
            {
                return val ?? string.Empty;
            }
        }

        /// <summary>
        /// Get value from umbraco properties by store
        /// Retrieves a store specific property <para/>
        /// alias name = field + "_" + storeAlias <para/>
        /// f.x. disabled_IS
        /// </summary>
        public static bool HasPropertyValue(this IReadOnlyDictionary<string, string> properties, string propertyAlias, string storeAlias = null, string language = null)
        {
            if (!string.IsNullOrEmpty(language))
            {
                propertyAlias = propertyAlias + "_" + language.ToLowerInvariant();
            }

            if (properties.ContainsKey(propertyAlias))
            {
                if (!string.IsNullOrEmpty(GetPropertyValue(properties, propertyAlias, storeAlias)))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
