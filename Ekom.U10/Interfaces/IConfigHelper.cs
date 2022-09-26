using System.Xml.Linq;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace Ekom.Interfaces
{
    public interface IConfigHelper
    {
        XDocument GetUmbracoSettingsFile();
        UrlMode GetUrlMode();
        UrlMode GetUrlModeCached();
    }
}
