using Quiplogs.WorkOrder.Dto.Repositories.WorkOrderTask;
using System.Threading.Tasks;

namespace Quiplogs.WorkOrder.Interfaces.Repositories
{
    public interface IWorkOrderTaskRepository
    {
        Task<ListWorkOrderTaskResponse> List(string workOrderId, int pageNumber, int pageSize);
        int GetTotalRecords(string companyId);
        Task<PutWorkOrderTaskResponse> Put(Domain.Entities.WorkOrderTask WorkOrderTask);
        Task<RemoveWorkOrderTaskResponse> Remove(string id);
    }
}
