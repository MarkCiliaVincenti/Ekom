using Ekom.Interfaces;
using Ekom.Models.Behaviors;
using Ekom.Utilities;
using Examine;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Core.Models;
using Umbraco.Core.Models.PublishedContent;

namespace Ekom.Models
{
    /// <summary>
    /// F.x. Borgun/Valitor
    /// </summary>
    public class PaymentProvider : PerStoreNodeEntity, IPerStoreNodeEntity, IPaymentProvider
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual string Name => Properties["nodeName"];

        /// <summary>
        /// Ranges and zones
        /// </summary>
        public virtual IConstraints Constraints { get; }

        /// <summary>
        /// 
        /// </summary>
        public virtual IPrice Price
        {
            get
            {
                if (HttpContext.Current != null)
                {
                    var cookie = HttpContext.Current.Request.Cookies["EkomCurrency-" + Store.Alias];

                    if (cookie != null && !string.IsNullOrEmpty(cookie.Value))
                    {
                        var price = Prices.FirstOrDefault(x => x.Currency.CurrencyValue == cookie.Value);

                        if (price != null)
                        {
                            return price;
                        }
                    }

                }

                return Prices.FirstOrDefault();

            }
        }

        /// <summary>
        /// 
        /// </summary>
        public virtual List<IPrice> Prices
        {
            get
            {
                var Prices = Properties.GetPropertyValue("price", Store.Alias).GetPriceValues(Store.Currencies, Store.Vat, Store.VatIncludedInPrice, Store.Currency);

                return Prices;
            }
        }

        /// <summary>
        /// Used by Ekom extensions
        /// </summary>
        /// <param name="store"></param>
        public PaymentProvider(IStore store) : base(store) { }

        /// <summary>
        /// Construct PaymentProvider from Examine item
        /// </summary>
        /// <param name="item"></param>
        /// <param name="store"></param>
        public PaymentProvider(IPublishedContent item, IStore store) : base(item, store)
        {
            Constraints = new Constraints(this);
        }

        /// <summary>
        /// Construct PaymentProvider from umbraco publish event
        /// </summary>
        /// <param name="node"></param>
        /// <param name="store"></param>
        public PaymentProvider(IContent node, IStore store) : base(node, store)
        {
            Constraints = new Constraints(this);
        }
    }
}