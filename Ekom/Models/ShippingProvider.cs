using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ekom.Core.Models
{
    /// <summary>
    /// F.x. home delivery or pickup.
    /// </summary>
    public class ShippingProvider : PerStoreNodeEntity, IShippingProvider
    {
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
        public ShippingProvider(IStore store) : base(store) { }

        /// <summary>
        /// Construct ShippingProvider
        /// </summary>
        /// <param name="item"></param>
        /// <param name="store"></param>
        public ShippingProvider(UmbracoContent item, IStore store) : base(item, store)
        {
            Constraints = new Constraints(this);
        }
    }
}
