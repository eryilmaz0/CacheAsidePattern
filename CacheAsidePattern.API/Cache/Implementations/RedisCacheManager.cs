using CacheAsidePattern.API.Cache.Interfaces;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CacheAsidePattern.API.Cache.Implementations
{
    public class RedisCacheManager : ICacheManager
    {
        private readonly IDistributedCache _redisCache;


        public RedisCacheManager(IDistributedCache redisCache)
        {
            _redisCache = redisCache;
        }



        public TReturnType GetFromCache<TReturnType>(string key)
        {
            if (this.IsKeyExist(key))
            {
                string value = this._redisCache.GetString(key);
                return JsonConvert.DeserializeObject<TReturnType>(value);
            }

            return default(TReturnType);
        }


        public bool IsKeyExist(string key)
        {
            return this._redisCache.GetString(key) != null ? true : false;
        }


        public void SetToCache<TValueType>(string key, TValueType value)
        {
            this._redisCache.SetString(key, JsonConvert.SerializeObject(value));        
        }
    }
}
