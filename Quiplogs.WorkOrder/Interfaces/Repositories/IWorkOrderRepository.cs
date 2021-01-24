using Quiplogs.WorkOrder.Dto.Repositories.WorkOrder;
using System;
using System.Threading.Tasks;

namespace Quiplogs.WorkOrder.Interfaces.Repositories
{
    public interface IWorkOrderRepository
    {
        Task<ListWorkOrderResponse> List(Guid companyId, Guid locationId, Guid assetId, int pageNumber, int pageSize);
        Task<int> GetTotalRecords(Guid companyId, Guid assetId);
        Task<GetWorkOrderResponse> Get(Guid id);
        Task<PutWorkOrderResponse> Put(Domain.Entities.WorkOrderEntity WorkOrder);
        Task<RemoveWorkOrderResponse> Remove(Guid id);
    }
}
