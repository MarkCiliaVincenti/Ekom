﻿using Examine;
using Umbraco.Core.Models;
using uWebshop.Models;

namespace uWebshop.Interfaces
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
        /// <param name="store"></param>
        /// <returns></returns>
        T Create(SearchResult item, Store store);

        /// <summary>
        /// Create object from Umbraco event with explicit store
        /// </summary>
        /// <param name="item">Examine item</param>
        /// <param name="store"></param>
        /// <returns></returns>
        T Create(IContent item, Store store);
    }
}
