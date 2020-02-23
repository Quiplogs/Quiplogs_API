using Quiplogs.WorkOrder.Dto.Repositories.WorkOrder;
using System.Threading.Tasks;

namespace Quiplogs.WorkOrder.Interfaces.Repositories
{
    public interface IWorkOrderRepository
    {
        Task<ListWorkOrderResponse> List(string companyId, string locationId, int pageNumber, int pageSize);
        Task<int> GetTotalRecords(string companyId);
        Task<GetWorkOrderResponse> Get(string id);
        Task<PutWorkOrderResponse> Put(Domain.Entities.WorkOrder WorkOrder);
        Task<RemoveWorkOrderResponse> Remove(string id);
    }
}
