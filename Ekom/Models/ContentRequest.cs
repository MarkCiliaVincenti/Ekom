using Azure.Core;
using Microsoft.AspNetCore.Http;
using System.Text.RegularExpressions;

namespace Ekom.Models
{
    class ContentRequest
    {
        private readonly HttpRequest _httpCtxRequest;
        private readonly HttpContext _httpResponse;
        public ContentRequest(HttpRequest httpContextRequest, HttpContext httpResponse)
        {
            _httpCtxRequest = httpContextRequest;
            _httpResponse = httpResponse;
        }

        private IStore _store;
        public IStore Store
        {
            get { return _store; }

            set
            {
                // Make sure to update users cookies on store change
                var legacyCookie = _httpResponse.Request.Cookies["StoreInfo"];
                legacyCookie = Regex.Replace(legacyCookie, "(StoreAlias =)[^&]", value.Alias);
                _httpResponse.Response.Cookies.Append("StoreInfo", legacyCookie);

                _store = value;
            }
        }

        public object Currency { get; set; }
        public string IPAddress => _httpCtxRequest.Host.ToString();
        public IProduct Product { get; set; }
        public ICategory Category { get; set; }
        public User User { get; set; }
    }
}
