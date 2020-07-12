using Quiplogs.Assets.Dto.Repositories.AssetUsage;
using System.Threading.Tasks;

namespace Quiplogs.Assets.Interfaces.Repositories
{
    public interface IAssetUsageRepository
    {
        Task<ListAssetUsageResponse> GetAll(string assetId, int pageNumber, int pageSize);
        Task<int> GetTotalRecords(string companyId);
        Task<GetAssetUsageResponse> Get(string id);
        Task<PutAssetUsageResponse> Put(Domain.Entities.AssetUsage Asset);
        Task<RemoveAssetUsageResponse> Remove(string id);
    }
}
