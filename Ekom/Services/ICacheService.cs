using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ekom.Services
{
    public interface ICacheService
    {
        /// <summary>
        /// Add the value into request cache. If the key already exists, the value is overwritten.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <typeparam name="TValue"></typeparam>
        void Add<TValue>(string key, TValue value);
        /// <summary>
        /// Remove the key from the request cache
        /// </summary>
        /// <param name="key"></param>
        void Remove(string key);
        /// <summary>
        /// Retrieve the value by key, if the key is not in the cache then the add func is called
        /// adding the value to cache and returning the added value.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="add"></param>
        /// <typeparam name="TValue"></typeparam>
        /// <returns></returns>
        TValue GetOrAdd<TValue>(string key, Func<TValue> add);
        /// <summary>
        /// Retrieves the value by key. When the key does not exist the default value for the type is returned.
        /// </summary>
        /// <param name="key"></param>
        /// <typeparam name="TValue"></typeparam>
        /// <returns></returns>
        TValue Get<TValue>(string key);
    }
}
