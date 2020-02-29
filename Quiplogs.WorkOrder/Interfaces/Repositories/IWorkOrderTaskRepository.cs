using Quiplogs.WorkOrder.Dto.Repositories.WorkOrderTask;
using System.Threading.Tasks;

namespace Quiplogs.WorkOrder.Interfaces.Repositories
{
    public interface IWorkOrderTaskRepository
    {
        Task<ListWorkOrderTaskResponse> List(string companyId, string locationId, string workOrderId, string assetId, int pageNumber);
        Task<int> GetTotalRecords(string companyId);
        Task<PutWorkOrderTaskResponse> Put(Domain.Entities.WorkOrderTask WorkOrderTask);
        Task<RemoveWorkOrderTaskResponse> Remove(string id);
    }
}
