﻿using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace Quiplogs.Core.Helpers
{
    public class Caching : ICaching
    {
        private readonly IDistributedCache _cache;

        public Caching(IDistributedCache cache)
        {
            _cache = cache;
        }

        public async Task SetAsnyc(string key, object value)
        {
            await _cache.SetStringAsync(key, JsonConvert.SerializeObject(value));
        }

        public async Task<T> GetAsnyc<T>(string key)
        {
            var encodedCachedObject = await _cache.GetStringAsync(key);

            if(encodedCachedObject == null)
            {
                return default;
            }

            return JsonConvert.DeserializeObject<T>(encodedCachedObject);
        }
    }
}
