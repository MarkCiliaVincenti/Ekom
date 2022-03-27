using Ekom.API;
using Ekom.Exceptions;
using Ekom.Interfaces;
using Ekom.Utilities;
using Examine;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Script.Serialization;
using System.Xml.Serialization;
using Umbraco.Core;
using Umbraco.Core.Models;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;
using Umbraco.Web.Composing;

namespace Ekom.Models
{
    /// <summary>
    /// Groups multiple <see cref="IVariant"/>'s together with a group key, 
    /// common properties and a shared parent <see cref="IProduct"/>
    /// </summary>
    public class VariantGroup : PerStoreNodeEntity, IVariantGroup
    {
        /// <summary>
        /// Parent <see cref="IProduct"/> of Variant
        /// </summary>
        public IProduct Product { get; internal set; }

        /// <summary>
        /// 
        /// </summary>
        public int ProductId => Product?.Id ?? 0;

        /// <summary>
        /// Get the Product Key
        /// </summary>
        public Guid ProductKey => Product?.Key ?? Guid.Empty;

        /// <summary>
        /// Get the Primary variant price, if no variants then fallback to product price
        /// </summary>
        public IPrice Price
        {
            get
            {
                var variants = Variants;

                if (variants.Any())
                {
                    return variants.FirstOrDefault().Price;
                }

                return Product.Price;
            }
        }

        // Waiting for variants to be composed with their parent product
        ///// <summary>
        ///// Get the Product Key
        ///// </summary>
        //public Guid ProductKey => Product.Key;
        ///// <summary>
        ///// 
        ///// </summary>
        //public int ProductId => Product.Id;

        // <summary>
        // Variant Group images
        // </summary>
        public virtual IEnumerable<Image> Images()
        {
            var _images = Properties.GetPropertyValue(Configuration.Current.CustomImage, Store.Alias);

            var imageNodes = _images.GetImages();

            return imageNodes;
        }

        /// <summary>
        /// Get all variants in this group
        /// </summary>
        [ScriptIgnore]
        [JsonIgnore]
        [XmlIgnore]
        public IEnumerable<IVariant> Variants
        {
            get
            {
                return Catalog.Instance.GetVariantsByGroup(Store.Alias, Id);
            }
        }

        /// <summary>
        /// Used by Ekom extensions
        /// </summary>
        /// <param name="store"></param>
        public VariantGroup(IStore store) : base(store) { }

        /// <summary>
        /// Construct Variant Group from Examine item
        /// </summary>
        /// <param name="item"></param>
        /// <param name="store"></param>
        public VariantGroup(IPublishedContent item, IStore store) : base(item, store)
        {
            var parentProduct = Catalog.Instance.GetProduct(store.Alias, item.Parent.Id);
            Product = parentProduct;
        }

        /// <summary>
        /// Construct Variant Group from umbraco publish event
        /// </summary>
        /// <param name="node"></param>
        /// <param name="store"></param>
        public VariantGroup(IContent node, IStore store) : base(node, store)
        {
            var pathArray = Path.Split(',');
            var productId = pathArray[pathArray.Count() - 2];
            var parentProduct = Catalog.Instance.GetProduct(store.Alias, Convert.ToInt32(productId));
            Product = parentProduct;
        }
    }
}