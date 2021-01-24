using Quiplogs.WorkOrder.Dto.Repositories.WorkOrderPart;
using System;
using System.Threading.Tasks;

namespace Quiplogs.WorkOrder.Interfaces.Repositories
{
    public interface IWorkOrderPartRepository
    {
        Task<ListWorkOrderPartResponse> List(Guid workOrderId, int pageNumber, int pageSize);
        int GetTotalRecords(Guid workOrderId);
        Task<PutWorkOrderPartResponse> Put(Domain.Entities.WorkOrderPart WorkOrderPart);
        Task<RemoveWorkOrderPartResponse> Remove(Guid id);
    }
}
