using System.Text.Json.Serialization;
using System.Web.Script.Serialization;
using System.Xml.Serialization;

namespace Ekom.Core.Models
{
    /// <summary>
    /// Base Per Store Umbraco node entity
    /// </summary>
    public abstract class PerStoreNodeEntity : NodeEntity, IPerStoreNodeEntity
    {
        /// <summary>
        /// Store this node entity belongs to
        /// </summary>
        [ScriptIgnore]
        [JsonIgnore]
        [XmlIgnore]
        public IStore Store { get; internal set; }

        /// <summary>
        /// 
        /// </summary>
        public override string Title => Properties.GetPropertyValue("title", Store.Alias);

        /// <summary>
        /// Get value in properties by store
        /// </summary>
        /// <param name="propertyAlias"></param>
        /// <param name="storeAlias"></param>
        public virtual string GetPropertyValue(string propertyAlias, string storeAlias)
        {
            return Properties.GetPropertyValue(propertyAlias, storeAlias);
        }

        /// <summary>
        /// ctor
        /// </summary>
        public PerStoreNodeEntity(IStore store)
        {
            Store = store;
        }

        /// <summary>
        /// Construct from IPublishedContent Item
        /// </summary>
        /// <param name="item"></param>
        /// <param name="store"></param>
        public PerStoreNodeEntity(UmbracoContent item, IStore store) : base(item)
        {
            Store = store;
        }
    }
}
