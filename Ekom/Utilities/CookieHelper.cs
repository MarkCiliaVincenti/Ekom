using Ekom.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows.Input;

namespace Ekom
{
    static class CookieHelper
    {
        public static CurrencyModel GetCurrencyCookieValue(List<CurrencyModel> currencies, string storeAlias)
        {
            var httpContext = Configuration.Resolver.GetService<HttpContext>();
            var cookie = httpContext?.Request?.Cookies["EkomCurrency-" + storeAlias];
            
            if (!string.IsNullOrEmpty(cookie))
            {
                var c = currencies.FirstOrDefault(x => x.CurrencyValue == cookie);

                if (c != null)
                {
                    return c;
                }
            }

            return currencies.FirstOrDefault();
        }

        public static void SetUmbracoDomain(System.Web.HttpCookieCollection cookieCollection, Uri uri)
            => cookieCollection[Configuration.Cookie_UmbracoDomain].Value = uri.ToString();

        public static Uri GetUmbracoDomain(System.Web.HttpCookieCollection cookieCollection)
        {
            var umbracoDomain = cookieCollection[Configuration.Cookie_UmbracoDomain];
            Uri.TryCreate(umbracoDomain?.Value, UriKind.Absolute, out var uri);

            return uri;
        }
    }
}
