using Examine;
using Umbraco.Core.Models;
using Umbraco.Core.Models.PublishedContent;

namespace Ekom.Interfaces
{
    /// <summary>
    /// Create object of type T
    /// </summary>
    /// <typeparam name="T">Object type factory creates</typeparam>
    public interface IPerStoreFactory<T>
    {
        /// <summary>
        /// Create object from IPublishedContent with explicit store
        /// </summary>
        /// <param name="item">IPublishedContent item</param>
        /// <param name="store"></param>
        /// <returns></returns>
        T Create(IPublishedContent item, IStore store);

        /// <summary>
        /// Create object from Umbraco event with explicit store
        /// </summary>
        /// <param name="item">Examine item</param>
        /// <param name="store"></param>
        /// <returns></returns>
        T Create(IContent item, IStore store);
    }
}
