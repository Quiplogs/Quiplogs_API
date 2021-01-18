using Quiplogs.Assets.Dto.Repositories.Asset;
using System;
using System.Threading.Tasks;

namespace Quiplogs.Assets.Interfaces.Repositories
{
    public interface IAssetRepository
    {
        Task<FetchAssetResponse> GetAll(Guid companyId, Guid? locationId, int pageNumber, int pageSize);
        Task<int> GetTotalRecords(Guid companyId);
        Task<GetAssetResponse> Get(Guid id);
        Task<PutAssetResponse> Put(Domain.Entities.Asset Asset);
        Task<RemoveAssetResponse> Remove(Guid id);
    }
}
