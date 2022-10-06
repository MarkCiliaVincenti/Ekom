//using Ekom.Interfaces;
//using System;
//using System.Collections.Generic;

//namespace Ekom.Cache
//{
//    public class RequestCache : IRequestCache
//    {
//        public IDictionary<string, object> _cache = new Dictionary<string, object>();
//        /// <summary>
//        /// Add the value into request cache. If the key already exists, the value is overwritten.
//        /// </summary>
//        /// <param name="key"></param>
//        /// <param name="value"></param>
//        /// <typeparam name="TValue"></typeparam>
//        public void Add<TValue>(string key, TValue value)
//        {
//            _cache[key] = value;
//        }
//        /// <summary>
//        /// Remove the key from the request cache
//        /// </summary>
//        /// <param name="key"></param>
//        public void Remove(string key)
//        {
//            if (_cache.ContainsKey(key))
//            {
//                _cache.Remove(key);
//            }
//        }
//        /// <summary>
//        /// Retrieve the value by key, if the key is not in the cache then the add func is called
//        /// adding the value to cache and returning the added value.
//        /// </summary>
//        /// <param name="key"></param>
//        /// <param name="add"></param>
//        /// <typeparam name="TValue"></typeparam>
//        /// <returns></returns>
//        public TValue RetrieveOrAdd<TValue>(string key, Func<TValue> add)
//        {
//            if (_cache.ContainsKey(key))
//            {
//                return (TValue)_cache[key];
//            }
//            var value = add();
//            _cache[key] = value;
//            return value;
//        }
//        /// <summary>
//        /// Retrieves the value by key. When the key does not exist the default value for the type is returned.
//        /// </summary>
//        /// <param name="key"></param>
//        /// <typeparam name="TValue"></typeparam>
//        /// <returns></returns>
//        public TValue Retrieve<TValue>(string key)
//        {
//            if (_cache.ContainsKey(key))
//            {
//                return (TValue)_cache[key];
//            }
//            return default(TValue);
//        }
//    }
//}
