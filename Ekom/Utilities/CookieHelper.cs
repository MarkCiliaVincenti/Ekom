using Ekom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Umbraco.Core;
using Umbraco.Core.Composing;

namespace Ekom.Utilities
{
    public class CookieHelper
    {
        public static CurrencyModel GetCurrencyCookieValue(List<CurrencyModel> currencies, string storeAlias)
        {
            var httpContext = Current.Factory.GetInstance<HttpContextBase>();
            var cookie = httpContext?.Request?.Cookies["EkomCurrency-" + storeAlias];

            if (!string.IsNullOrEmpty(cookie?.Value))
            {
                var c = currencies.FirstOrDefault(x => x.CurrencyValue == cookie.Value);

                if (c != null)
                {
                    return c;
                }
            }

            return currencies.FirstOrDefault();
        }
    }
}
