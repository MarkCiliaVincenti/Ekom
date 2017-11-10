﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Umbraco.Core.Models;
using Umbraco.Web;
using Umbraco.Web.Routing;

namespace Ekom
{
    class CatalogUrlProvider : IUrlProvider
    {
        public string GetUrl(UmbracoContext umbracoContext, int id, Uri current, UrlProviderMode mode)
        {
            var content = umbracoContext.ContentCache.GetById(id);

            if (content != null && (content.DocumentTypeAlias == "ekmProduct" || content.DocumentTypeAlias == "ekmCategory"))
            {
                StringBuilder builder = new StringBuilder();

                foreach (IPublishedContent node in content.AncestorsOrSelf().Where(x => x.DocumentTypeAlias == "ekmProduct" || x.DocumentTypeAlias == "ekmCategory").Reverse())
                {
                    string slug = node.HasProperty("slug") && node.HasValue("slug") ? node.GetPropertyValue<string>("slug") : node.UrlName;

                    builder.AppendFormat("/{0}", slug);
                }

                return builder.ToString();
            }

            return null;
        }

        public IEnumerable<string> GetOtherUrls(UmbracoContext umbracoContext, int id, Uri current)
        {
            return Enumerable.Empty<string>();
        }
    }
}