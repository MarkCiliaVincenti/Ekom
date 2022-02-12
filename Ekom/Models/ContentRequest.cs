using System.Web;


namespace Ekom.Core.Models
{
    class ContentRequest
    {
        private readonly HttpContextBase _httpCtx;
        public ContentRequest(HttpContextBase httpContext)
        {
            _httpCtx = httpContext;
        }

        private IStore _store;
        public IStore Store
        {
            get { return _store; }

            set
            {
                // Make sure to update users cookies on store change
                _httpCtx.Response.Cookies["StoreInfo"].Values["StoreAlias"] = value.Alias;

                _store = value;
            }
        }

        public object Currency { get; set; }
        public string IPAddress => _httpCtx.Request.UserHostAddress;
        public IProduct Product { get; set; }
        public ICategory Category { get; set; }
        public User User { get; set; }
    }
}
