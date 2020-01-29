using System.Threading.Tasks;

namespace Api.Core.Helpers
{
    public interface ICaching
    {
        Task SetAsnyc(string key, object value);

        Task<T> GetAsnyc<T>(string key);
    }
}
