using Quiplogs.WorkOrder.Dto.Repositories.WorkOrderPart;
using System.Threading.Tasks;

namespace Quiplogs.WorkOrder.Interfaces.Repositories
{
    public interface IWorkOrderPartRepository
    {
        Task<ListWorkOrderPartResponse> List(string workOrderId, int pageNumber, int pageSize);
        int GetTotalRecords(string workOrderId);
        Task<PutWorkOrderPartResponse> Put(Domain.Entities.WorkOrderPart WorkOrderPart);
        Task<RemoveWorkOrderPartResponse> Remove(string id);
    }
}
