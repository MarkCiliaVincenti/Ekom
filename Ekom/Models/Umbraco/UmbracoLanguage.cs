using System.Globalization;

namespace EkomCore.Models.Umbraco
{
    public class UmbracoLanguage
    {
        public string IsoCode { get; set; }
        public string CultureName { get; set; }
        public CultureInfo Culture { get; set; }
    }
}
