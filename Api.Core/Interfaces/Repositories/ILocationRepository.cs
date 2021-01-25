using System;
using System.Threading.Tasks;
using Quiplogs.Core.Dto.Repositories.Location;

namespace Quiplogs.Core.Interfaces.Repositories
{
    public interface ILocationRepository
    {
        Task<ListLocationResponse> List(Guid companyId, int pageNumber, string filterName, int pageSize);
        Task<int> GetTotalRecords(Guid companyId);
        Task<GetLocationResponse> Get(Guid id);
        Task<PutLocationResponse> Put(Domain.Entities.Location Location);
        Task<RemoveLocationResponse> Remove(Guid id);
        Task RemoveImage(Guid id);
    }
}
