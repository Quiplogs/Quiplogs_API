using Quiplogs.Inventory.Dto.Repositories.Task;
using System.Threading.Tasks;

namespace Quiplogs.Inventory.Interfaces.Repositories
{ 
    public interface ITaskRepository
    {
        Task<ListTaskResponse> List(string companyId, int pageNumber, int pageSize);
        Task<int> GetTotalRecords(string companyId);
        Task<GetTaskResponse> Get(string id);
        Task<PutTaskResponse> Put(Domain.Entities.TaskEntity Task);
        Task<RemoveTaskResponse> Remove(string id);
    }
}
