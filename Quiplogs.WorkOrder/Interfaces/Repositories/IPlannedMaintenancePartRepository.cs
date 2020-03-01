using Quiplogs.WorkOrder.Dto.Repositories.PlannedMaintenancePart;
using System.Threading.Tasks;

namespace Quiplogs.WorkOrder.Interfaces.Repositories
{
    public interface IPlannedMaintenancePartRepository
    {
        Task<ListPlannedMaintenancePartResponse> List(string plannedMaintenanceId, int pageNumber, int pageSizer);
        int GetTotalRecords(string plannedMaintenanceId);
        Task<PutPlannedMaintenancePartResponse> Put(Domain.Entities.PlannedMaintenancePart PlannedMaintenancePart);
        Task<RemovePlannedMaintenancePartResponse> Remove(string id);
    }
}
