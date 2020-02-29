using Quiplogs.WorkOrder.Dto.Repositories.WorkOrderPart;
using System.Threading.Tasks;

namespace Quiplogs.WorkOrder.Interfaces.Repositories
{
    public interface IWorkOrderPartRepository
    {
        Task<ListWorkOrderPartResponse> List(string companyId, string locationId, string workOrderId, string assetId, int pageNumber);
        Task<int> GetTotalRecords(string companyId);
        Task<PutWorkOrderPartResponse> Put(Domain.Entities.WorkOrderPart WorkOrderPart);
        Task<RemoveWorkOrderPartResponse> Remove(string id);
    }
}
