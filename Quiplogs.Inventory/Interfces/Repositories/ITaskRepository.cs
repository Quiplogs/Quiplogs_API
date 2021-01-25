using System;
using System.Threading.Tasks;
using Quiplogs.Inventory.Dto.Repositories.Task;

namespace Quiplogs.Inventory.Interfces.Repositories
{ 
    public interface ITaskRepository
    {
        Task<ListTaskResponse> List(Guid companyId, int pageNumber, string filterName, int pageSize);
        Task<int> GetTotalRecords(Guid companyId);
        Task<GetTaskResponse> Get(Guid id);
        Task<PutTaskResponse> Put(Domain.Entities.TaskEntity Task);
        Task<RemoveTaskResponse> Remove(Guid id);
    }
}
