using Examine;
using Umbraco.Core.Models;
using Umbraco.Core.Models.PublishedContent;

namespace Ekom.Interfaces
{
    /// <summary>
    /// Create object of type T
    /// </summary>
    /// <typeparam name="T">Object type factory creates</typeparam>
    public interface IObjectFactory<T>
    {
        /// <summary>
        /// Create object from Examine with explicit store
        /// </summary>
        /// <param name="item">Examine item</param>
        /// <returns></returns>
        T Create(IPublishedContent item);

        /// <summary>
        /// Create object from Umbraco event with explicit store
        /// </summary>
        /// <param name="item">Examine item</param>
        /// <returns></returns>
        T Create(IContent item);
    }
}
