using Quiplogs.Assets.Dto.Repositories.Asset;
using System.Threading.Tasks;

namespace Quiplogs.Assets.Interfaces.Repositories
{
    public interface IAssetRepository
    {
        Task<FetchAssetResponse> GetAll(string companyId, string locationId, int pageNumber, int pageSize);
        Task<int> GetTotalRecords(string companyId);
        Task<GetAssetResponse> Get(string id);
        Task<PutAssetResponse> Put(Domain.Entities.Asset Asset);
        Task<RemoveAssetResponse> Remove(string id);
    }
}
