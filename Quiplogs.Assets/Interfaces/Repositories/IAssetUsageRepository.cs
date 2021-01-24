using Quiplogs.Assets.Dto.Repositories.AssetUsage;
using System;
using System.Threading.Tasks;

namespace Quiplogs.Assets.Interfaces.Repositories
{
    public interface IAssetUsageRepository
    {
        Task<ListAssetUsageResponse> GetAll(Guid assetId, int pageNumber, int pageSize);
        Task<int> GetTotalRecords(Guid companyId);
        Task<GetAssetUsageResponse> Get(Guid id);
        Task<PutAssetUsageResponse> Put(Domain.Entities.AssetUsage Asset);
        Task<RemoveAssetUsageResponse> Remove(Guid id);
    }
}
