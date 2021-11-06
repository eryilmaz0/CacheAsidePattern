using CacheAsidePattern.API.Cache.Interfaces;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CacheAsidePattern.API.Cache.Implementations
{
    public class InMemoryCacheManager : ICacheManager
    {
        private readonly IMemoryCache _inMemoryCache;

        public InMemoryCacheManager(IMemoryCache inMemoryCache)
        {
            _inMemoryCache = inMemoryCache;
        }


        public TReturnType GetFromCache<TReturnType>(string key)
        {
            if (this.IsKeyExist(key))
                return this._inMemoryCache.Get<TReturnType>(key);

            return default(TReturnType);          
        }


        public bool IsKeyExist(string key)
        {
            return this._inMemoryCache.TryGetValue(key, out _) ? true : false; 
        }


        public void SetToCache<TValueType>(string key, TValueType value)
        {
            this._inMemoryCache.Set<TValueType>(key, value);
        }
    }
}
