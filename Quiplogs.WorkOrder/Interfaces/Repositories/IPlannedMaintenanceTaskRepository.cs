using Quiplogs.WorkOrder.Dto.Repositories.PlannedMaintenanceTask;
using System.Threading.Tasks;

namespace Quiplogs.WorkOrder.Interfaces.Repositories
{
    public interface IPlannedMaintenanceTaskRepository
    {
        Task<ListPlannedMaintenanceTaskResponse> List(string companyId, string locationId, string plannedMaintenanceId, string assetId, int pageNumber);
        Task<int> GetTotalRecords(string companyId);
        Task<PutPlannedMaintenanceTaskResponse> Put(Domain.Entities.PlannedMaintenanceTask PlannedMaintenanceTask);
        Task<RemovePlannedMaintenanceTaskResponse> Remove(string id);
    }
}
