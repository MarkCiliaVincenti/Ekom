
using System.Collections.Generic;
using System.Linq;

#if NETCOREAPP
using Microsoft.AspNetCore.Http;
#else
using System.Web;
#endif

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

                    if (cookie != null && !string.IsNullOrEmpty(cookie))
                    {
                        var price = Prices.FirstOrDefault(x => x.Currency.CurrencyValue == cookie);

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
        /// Construct PaymentProvider
        /// </summary>
        /// <param name="item"></param>
        /// <param name="store"></param>
        public PaymentProvider(UmbracoContent item, IStore store) : base(item, store)
        {
            Constraints = new Constraints(this);
        }
    }
}
