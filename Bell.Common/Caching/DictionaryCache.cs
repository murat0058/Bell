using System;
using Microsoft.Extensions.Caching.Memory;

namespace Bell.Common.Caching
{
    public interface IDictionaryCache<TValue>
    {
        /// <summary>
        /// Sets the value and key in the cache
        /// </summary>
        /// <param name="key">The key for the value to be stored</param>
        /// <param name="value">The value to store</param>
        void Set(string key, TValue value);

        /// <summary>
        /// Gets the value associated with the key in memory
        /// </summary>
        /// <param name="key">The key</param>
        /// <returns>The associated value</returns>
        TValue Get(string key);

        /// <summary>
        /// Tries to get the value associated with the specified key
        /// </summary>
        /// <param name="key">The key</param>
        /// <param name="value">The associated value</param>
        /// <returns>True if the key is found; otherwise false</returns>
        bool TryGetValue(string key, out TValue value);

        /// <summary>
        /// Removes the key from the cache
        /// </summary>
        /// <param name="key">The key to remove</param>
        void Remove(string key);
    }

    public abstract class DictionaryCache<TValue> : IDictionaryCache<TValue>
    {
        #region Private Fields

        private readonly IMemoryCache _memoryCache;
        private readonly MemoryCacheEntryOptions _memoryEntryCacheOptions;
        private readonly string _cacheName;

        #endregion

        #region Constructors

        protected DictionaryCache(IMemoryCache memoryCache, TimeSpan slidingExpiration, string cacheName)
        {
            _memoryCache = memoryCache;
            _memoryEntryCacheOptions = new MemoryCacheEntryOptions {SlidingExpiration = slidingExpiration};
            _cacheName = cacheName;
        }

        #endregion

        #region Public Methods

        public void Set(string key, TValue value)
        {
            _memoryCache.Set(GenerateFullKeyName(key), value, _memoryEntryCacheOptions);
        }

        public TValue Get(string key)
        {
            return _memoryCache.Get<TValue>(GenerateFullKeyName(key));
        }

        public bool TryGetValue(string key, out TValue value)
        {
            return _memoryCache.TryGetValue(GenerateFullKeyName(key), out value);
        }

        public void Remove(string key)
        {
            _memoryCache.Remove(GenerateFullKeyName(key));
        }

        #endregion

        #region Private Methods

        private string GenerateFullKeyName(string key)
        {
            return $"{_cacheName}_{key}";
        }

        #endregion
    }
}
