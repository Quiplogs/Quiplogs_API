using Quiplogs.Inventory.Dto.Repositories.Part;
using System;
using System.Threading.Tasks;

namespace Quiplogs.Inventory.Interfaces.Repositories
{
    public interface IPartRepository
    {
        Task<ListPartResponse> List(Guid companyId, Guid locationId, string filterName, int pageNumber, int pageSize);
        Task<int> GetTotalRecords(Guid companyId);
        Task<GetPartResponse> Get(Guid id);
        Task<PutPartResponse> Put(Domain.Entities.Part Part);
        Task<RemovePartResponse> Remove(Guid id);
    }
}
