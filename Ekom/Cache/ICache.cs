using System;

namespace Ekom.Core.Cache
{
    /// <summary>
    /// Caches implementing this interface offer addition and removal methods
    /// for usage by umbraco event listeners
    /// </summary>
    public interface ICache
    {
        /// <summary>
        /// Umbraco Node Alias name used in Examine search
        /// </summary>
        string NodeAlias { get; }

        /// <summary>
        /// Handles addition of nodes when umbraco events fire
        /// </summary>
        void AddReplace(IContent node);

        /// <summary>
        /// Handles addition of nodes when umbraco events fire
        /// </summary>
        void AddReplace(IPublishedContent node);

        /// <summary>
        /// Handles removal of nodes when umbraco events fire
        /// </summary>
        void Remove(Guid id);

        /// <summary>
        /// Handles initial population of cache data
        /// </summary>
        void FillCache();
    }
}
