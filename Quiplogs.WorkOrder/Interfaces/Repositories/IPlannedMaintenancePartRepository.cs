using Quiplogs.WorkOrder.Dto.Repositories.PlannedMaintenancePart;
using System.Threading.Tasks;

namespace Quiplogs.WorkOrder.Interfaces.Repositories
{
    public interface IPlannedMaintenancePartRepository
    {
        Task<ListPlannedMaintenancePartResponse> List(string companyId, string locationId, string plannedMaintenanceId, string assetId, int pageNumber);
        Task<int> GetTotalRecords(string companyId);
        Task<PutPlannedMaintenancePartResponse> Put(Domain.Entities.PlannedMaintenancePart PlannedMaintenancePart);
        Task<RemovePlannedMaintenancePartResponse> Remove(string id);
    }
}
