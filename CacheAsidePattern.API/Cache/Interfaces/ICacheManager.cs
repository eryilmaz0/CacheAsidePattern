using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CacheAsidePattern.API.Cache.Interfaces
{
    public interface ICacheManager
    {
        TReturnType GetFromCache<TReturnType>(string key);
        void SetToCache<TValueType>(string key, TValueType value);
        bool IsKeyExist(string key);
    }
}
