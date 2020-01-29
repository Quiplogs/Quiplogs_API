using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace Api.Core.Helpers
{
    internal class Caching : ICaching
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
            return JsonConvert.DeserializeObject<T>(encodedCachedObject);
        }
    }
}
