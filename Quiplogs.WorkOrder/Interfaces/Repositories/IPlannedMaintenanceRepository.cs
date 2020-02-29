using Quiplogs.WorkOrder.Dto.Repositories.PlannedMaintenance;
using System.Threading.Tasks;

namespace Quiplogs.WorkOrder.Interfaces.Repositories
{
    public interface IPlannedMaintenanceRepository
    {
        Task<ListPlannedMaintenanceResponse> List(string companyId, string locationId, string workOrderId, string assetId, int pageNumber);
        Task<int> GetTotalRecords(string companyId);
        Task<GetPlannedMaintenanceResponse> Get(string id);
        Task<PutPlannedMaintenanceResponse> Put(Domain.Entities.PlannedMaintenance PlannedMaintenance);
        Task<RemovePlannedMaintenanceResponse> Remove(string id);
    }
}
