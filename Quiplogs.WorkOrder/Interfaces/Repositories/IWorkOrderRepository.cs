using Quiplogs.WorkOrder.Dto.Repositories.WorkOrder;
using System.Threading.Tasks;

namespace Quiplogs.WorkOrder.Interfaces.Repositories
{
    public interface IWorkOrderRepository
    {
        Task<ListWorkOrderResponse> List(string companyId, string locationId, string assetId, int pageNumber, int pageSize);
        Task<int> GetTotalRecords(string companyId, string assetId);
        Task<GetWorkOrderResponse> Get(string id);
        Task<PutWorkOrderResponse> Put(Domain.Entities.WorkOrderEntity WorkOrder);
        Task<RemoveWorkOrderResponse> Remove(string id);
    }
}
