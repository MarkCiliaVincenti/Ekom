using Ekom.Cache;
using Ekom.Services;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;


namespace Ekom.Models
{
    /// <summary>
    /// Categories are groupings of products, categories can also be nested, f.x.
    /// Women->Winter->Shirts
    /// </summary>
    public class Category : PerStoreNodeEntity, IPerStoreNodeEntity, ICategory
    {
        private IPerStoreCache<ICategory> _categoryCache => Configuration.Resolver.GetService<IPerStoreCache<ICategory>>();
        private IPerStoreCache<IProduct> _productCache => Configuration.Resolver.GetService<IPerStoreCache<IProduct>>();

        /// <summary>
        /// Short spaceless descriptive title used to create URLs
        /// </summary>
        public string Slug => Properties.GetPropertyValue("slug", base.Store.Alias);

        /// <summary>
        /// All category Urls, computed from stores
        /// </summary>
        public IEnumerable<string> Urls { get; set; }
        /// <summary>
        /// Our eldest ancestor category
        /// </summary>
        public ICategory RootCategory
        {
            get
            {
                return Ancestors().FirstOrDefault();
            }
        }

        /// <inheritdoc/>
        public virtual string Url
        {
            get
            {
                var urlSvc = Configuration.Resolver.GetService<IUrlService>();
                return urlSvc.GetNodeEntityUrl(this);
            }
        }

        /// <summary>
        /// All direct child categories
        /// </summary>
        public IEnumerable<ICategory> SubCategories
        {
            get
            {
                return _categoryCache.Cache[Store.Alias]
                    .Where(x => x.Value.Ancestors().Any(z => z.Id == Id))
                    .Select(x => x.Value)
                    .OrderBy(x => x.SortOrder);
            }
        }

        /// <summary>
        /// All direct child products of category. (No descendants)
        /// </summary>
        [JsonIgnore]
        public IEnumerable<IProduct> Products
        {
            get
            {
                return _productCache.Cache[Store.Alias]
                                   .Where(x => x.Value.Categories.Any(z => z.Id == Id))
                                   .Select(x => x.Value)
                                   .OrderBy(x => x.SortOrder);
            }
        }

        /// <summary>
        /// All descendant categories, includes grandchild categories
        /// </summary>
        [JsonIgnore]
        [XmlIgnore]
        public IEnumerable<ICategory> SubCategoriesRecursive
        {
            get
            {
                return _categoryCache.Cache[Store.Alias]
                                    .Where(x => x.Value.Level > Level &&
                                                x.Value.Path.Split(',').Contains(Id.ToString()))
                                    .Select(x => x.Value)
                                    .OrderBy(x => x.SortOrder);
            }
        }

        /// <summary>
        /// All descendant products of category, this includes child products of sub-categories
        /// </summary>
        [JsonIgnore]
        [XmlIgnore]
        public IEnumerable<IProduct> ProductsRecursive
        {
            get
            {
                return _categoryCache.Cache[Store.Alias]
                                    .Where(x => x.Value.Level >= Level &&
                                                x.Value.Path.Split(',').Contains(Id.ToString()))
                                    .Select(x => x.Value)
                                    .OrderBy(x => x.SortOrder)
                                    .SelectMany(x => x.Products);
            }
        }

        /// <summary>
        /// All parent categories, grandparent categories and so on.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ICategory> Ancestors()
        {
            var list = new List<ICategory>();

            foreach (var id in Path.Split(','))
            {
                if (int.TryParse(id, out int categoryId))
                {
                    var category = _categoryCache.Cache[Store.Alias]
                        .FirstOrDefault(x => x.Value.Id == categoryId);

                    if (category.Value != null)
                    {
                        list.Add(category.Value);
                    }
                }
            }

            return list;
        }

        /// <summary>
        /// Used by Ekom extensions, keep logic empty to allow full customisation of object construction.
        /// </summary>
        /// <param name="store"></param>
        internal protected Category(IStore store) : base(store) { }
        /// <summary>
        /// Construct Category from IPublishedContent item
        /// </summary>
        /// <param name="item"></param>
        /// <param name="store"></param>
        internal protected Category(UmbracoContent item, IStore store) : base(item, store)
        {
            var urlSvc = Configuration.Resolver.GetService<IUrlService>();
            var nodeSvc = Configuration.Resolver.GetService<INodeService>();
            Urls = urlSvc.BuildCategoryUrls(nodeSvc.GetAllCatalogAncestors(item), store);
        }
    }
}
