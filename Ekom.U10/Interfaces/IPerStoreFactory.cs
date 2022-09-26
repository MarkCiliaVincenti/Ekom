using Ekom.Models;
using Umbraco.Cms.Core.Models;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace Ekom.Interfaces
{
    /// <summary>
    /// Create object of type T
    /// </summary>
    /// <typeparam name="T">Object type factory creates</typeparam>
    public interface IPerStoreFactory<T>
    {
        /// <summary>
        /// Create object from IContent with explicit store
        /// </summary>
        /// <param name="item">IContent item</param>
        /// <param name="store"></param>
        /// <returns></returns>
        T Create(IContent item, IStore store);
        /// <summary>
        /// Create object from IPublishedContent with explicit store
        /// </summary>
        /// <param name="item">IPublishedContent item</param>
        /// <param name="store"></param>
        /// <returns></returns>
        T Create(IPublishedContent item, IStore store);
    }
}
