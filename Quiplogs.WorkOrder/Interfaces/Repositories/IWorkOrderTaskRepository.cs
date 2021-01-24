using Quiplogs.WorkOrder.Dto.Repositories.WorkOrderTask;
using System;
using System.Threading.Tasks;

namespace Quiplogs.WorkOrder.Interfaces.Repositories
{
    public interface IWorkOrderTaskRepository
    {
        Task<ListWorkOrderTaskResponse> List(Guid workOrderId, int pageNumber, int pageSize);
        int GetTotalRecords(Guid companyId);
        Task<PutWorkOrderTaskResponse> Put(Domain.Entities.WorkOrderTask WorkOrderTask);
        Task<RemoveWorkOrderTaskResponse> Remove(Guid id);
    }
}
