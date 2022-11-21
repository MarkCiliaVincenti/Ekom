using Ekom;
using Ekom.Models;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System.Linq;
using Umbraco.Cms.Core.Models;
using Umbraco.Cms.Core.Services;

namespace EkomCore.U10.Utilities
{
    public static class ContentExtensions
    {
        // Set Ekom Property Value
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
        // Set Ekom Property Value
        public static void SetProperty(this IContent content, string alias, Dictionary<string, object> values)
        {
            if (content == null)
            {
                throw new ArgumentNullException("content");
            }

            if (string.IsNullOrEmpty(alias))
            {
                throw new ArgumentNullException("alias");
            }

            if (values == null)
            {
                throw new ArgumentNullException("values");
            }

            var property = content.Properties.FirstOrDefault(x => x.Alias.ToUpperInvariant() == alias.ToUpperInvariant());

            if (property != null)
            {
                var dts = Configuration.Resolver.GetService<IDataTypeService>();

                var editor = dts.GetByEditorAlias(property.PropertyType.PropertyEditorAlias);

                if (editor.Any())
                {
                    var dataType = editor.FirstOrDefault();

                    string value = JsonConvert.SerializeObject(new PropertyValue
                    {
                        DtdGuid = dataType.Key,
                        Values = values
                    });

                    content.SetValue(alias, value);

                    return;
                }

                throw new InvalidOperationException("Unable to get data type for property.");
            }

            throw new InvalidOperationException("Unable to find matching property on IContent.");
        }
        private static void SetProperty(this IContent content, string alias, string storeAlias, object value)
        {
            if (content == null)
            {
                throw new ArgumentNullException("content");
            }

            if (string.IsNullOrEmpty(alias))
            {
                throw new ArgumentNullException("alias");
            }

            if (string.IsNullOrEmpty(storeAlias))
            {
                throw new ArgumentNullException("storeAlias");
            }

            var property = content.Properties.FirstOrDefault(x => x.Alias.ToUpperInvariant() == alias.ToUpperInvariant());

            if (property != null)
            {
                var ekomProperty = content.GetEkomProperty(alias);

                var dictionary = new Dictionary<string, object>();
                if (ekomProperty != null && ekomProperty.Values != null && ekomProperty.Values.Any())
                {
                    foreach (KeyValuePair<string, object> value3 in ekomProperty.Values)
                    {
                        object value2 = ((value3.Key.ToUpperInvariant() == storeAlias.ToUpperInvariant()) ? value : value3.Value);
                        dictionary.Add(value3.Key, value2);
                    }
                }
                else
                {
                    dictionary.Add(storeAlias, value);
                }

                content.SetProperty(alias, dictionary);

                return;
            }

            throw new InvalidOperationException("Unable to find matching property on IContent.");
        }
        
        // Set Normal Umbraco value
        public static void SetProperty(this IContent content, string alias, object value, string culture = null)
        {
            content.SetValue(alias, value, culture);
        }

        /// <summary>
        /// Set a price value<para/>
        /// </summary>
        /// <param name="item"></param>
        /// <param name="storeAlias"></param>
        /// <param name="currency"></param>
        /// <param name="price"></param>
        /// <returns>Property Value</returns>
        public static void SetPrice(this IContent item, string storeAlias, string currency, decimal price)
        {
            if (item.HasProperty("price"))
            {

                var fieldValue = item.GetValue<string>("price");

                var currencyPrices = new List<CurrencyPrice>();

                if (!string.IsNullOrEmpty(fieldValue))
                {
                    try
                    {
                        var jsonCurrencyValue = fieldValue.GetEkomPropertyEditorValue(storeAlias);

                        currencyPrices = jsonCurrencyValue.GetCurrencyPrices();

                    }
                    catch
                    {

                    }
                }

                if (currencyPrices.Any(x => x.Currency == currency))
                {
                    currencyPrices.FirstOrDefault(x => x.Currency == currency).Price = price;

                }
                else
                {
                    currencyPrices.Add(new CurrencyPrice(price, currency));
                }

                item.SetProperty("price", storeAlias, currencyPrices);
            }

        }

        public static PropertyValue GetEkomProperty(this IContent content, string alias)
        {
            if (content == null)
            {
                throw new ArgumentNullException("content");
            }

            var property = content.Properties.FirstOrDefault(x => x.Alias.ToUpperInvariant() == alias.ToUpperInvariant());

            if (property == null)
            {
                throw new InvalidOperationException("Unable to find matching property on IContent.");
            }

            if (property.GetValue() != null)
            {
                return JsonConvert.DeserializeObject<PropertyValue>(property.GetValue().ToString());
            }

            return null;
        }

        // Get Ekom Property Value
        public static string GetProperty(this IContent content, string alias, string propertyAlias)
        {
            if (content == null)
            {
                throw new ArgumentNullException("content");
            }

            var property = GetEkomProperty(content, alias);

            if (property.Values.ContainsKey(propertyAlias))
            {
                return property?.Values.FirstOrDefault(x => x.Key == propertyAlias).Value.ToString();
            }

            return "";
            
        }

        public static decimal GetPrice(this IContent content, string storeAlias, string currency)
        {
            var fieldValue = content.GetProperty("price", storeAlias);

            if (!string.IsNullOrEmpty(fieldValue))
            {
                var currencyValues = fieldValue.GetCurrencyValues();

                var value = string.IsNullOrEmpty(currency) ? currencyValues.FirstOrDefault() : currencyValues.FirstOrDefault(x => x.Currency == currency);

                return value != null ? value.Value : 0;
            }

            return 0;
        }
    }
}
