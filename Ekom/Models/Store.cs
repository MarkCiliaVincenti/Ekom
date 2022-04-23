using Ekom.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Ekom.Cache;

namespace Ekom.Models
{
    /// <summary>
    /// Ekom Store, used to f.x. have seperate products and entities per store.
    /// </summary>
    public class Store : NodeEntity, IStore
    {
        protected IServiceProvider _serviceProvider;

        private INodeService nodeService => _serviceProvider.GetService<INodeService>();
        private IStoreDomainCache storeDomainCache => _serviceProvider.GetService<IStoreDomainCache>();
        /// <summary>
        /// Usually a two letter code, f.x. EU/IS/DK
        /// </summary>
        public virtual string Alias => Properties["nodeName"];
        public virtual int StoreRootNode { get; }
        public virtual IEnumerable<UmbracoDomain> Domains { get; }
        public virtual bool VatIncludedInPrice => Properties["vatIncludedInPrice"].ConvertToBool();
        public virtual string OrderNumberTemplate => Properties.GetPropertyValue("orderNumberTemplate");
        public virtual string OrderNumberPrefix => Properties.GetPropertyValue("orderNumberPrefix");
        public virtual string Url { get; }
        public virtual CultureInfo Culture
        {
            get
            {
                var ci = new CultureInfo(Properties["culture"]);

                return ci.TwoLetterISOLanguageName == "is" ? Configuration.IsCultureInfo : ci;
            }
        }
        public virtual CurrencyModel Currency
        {
            get
            {
                return GetCurrentCurrency();
            }
        }

        public CurrencyModel GetCurrentCurrency()
        {
            return CookieHelper.GetCurrencyCookieValue(Currencies, Alias);
        }

        public virtual List<CurrencyModel> Currencies
        {
            get
            {
                try
                {
                    var getString = Properties.GetPropertyValue("currency");
                    if (getString.Contains("["))
                    {
                        var deserialized = JsonConvert.DeserializeObject<List<CurrencyModel>>(getString);
                        return deserialized;
                    }
                    else
                    {
                        var c = Properties.ContainsKey("currency") && !string.IsNullOrEmpty(Properties["currency"]) ? Properties["currency"] : Culture.ToString();
                        var l = new List<CurrencyModel>();
                        l.Add(new CurrencyModel
                        {
                            CurrencyValue = c,
                            CurrencyFormat = "C"
                        });
                        return l;
                    }
                }
                catch (Exception ex)
                {
                    //Backword Compatability
                    var l = new List<CurrencyModel>();
                    l.Add(new CurrencyModel
                    {
                        CurrencyValue = Culture.ToString(),
                        CurrencyFormat = "C"
                    });
                    return l;
                }
            }


        }

        /// <summary>
        /// Umbraco input: 28.5 <para></para>
        /// Stored VAT value: 0.285<para></para>
        /// Effective VAT value: 28.5%<para></para>
        /// </summary>
        public virtual decimal Vat => string.IsNullOrEmpty(Properties.GetPropertyValue("vat"))
            ? 0
            : Convert.ToDecimal(Properties["vat"]) / 100;

        /// <summary>
        /// Used by Ekom extensions
        /// </summary>
        public Store() : base() { }
        /// <summary>
        /// Construct Store
        /// </summary>
        /// <param name="item"></param>
        public Store(UmbracoContent item) : base(item)
        {

            if (item.Properties.HasPropertyValue("storeRootNode"))
            {
                var storeRootNodeUdi = item.Properties.GetPropertyValue("storeRootNode");

                var storeRootNode = nodeService.NodeById(storeRootNodeUdi);

                if (storeRootNode != null)
                {
                    StoreRootNode = storeRootNode.Id;
                }

                Url = nodeService.GetUrl(storeRootNodeUdi);
            }

            if (storeDomainCache.Cache.Any(x => x.Value.RootContentId == StoreRootNode))
            {
                Domains = storeDomainCache.Cache
                    .Where(x => x.Value.RootContentId == StoreRootNode)
                    .Select(x => x.Value)
                    .ToList();
            }
            else
            {
                //TODO If not culture/domain is set then add default
                //if (uCtx.HttpContext != null)
                //{
                //    Domains = Enumerable.Repeat(new Domain(uCtx.HttpContext.Request.Url?.Host, StoreRootNode), 1);
                //}

            }
        }
    }
}
