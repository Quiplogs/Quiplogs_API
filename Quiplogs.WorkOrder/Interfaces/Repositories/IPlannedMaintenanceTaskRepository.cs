using Quiplogs.WorkOrder.Dto.Repositories.PlannedMaintenanceTask;
using System.Threading.Tasks;

namespace Quiplogs.WorkOrder.Interfaces.Repositories
{
    public interface IPlannedMaintenanceTaskRepository
    {
        Task<ListPlannedMaintenanceTaskResponse> List(string plannedMaintenanceId, int pageNumber, int pageSize);
        int GetTotalRecords(string plannedMaintenanceId);
        Task<PutPlannedMaintenanceTaskResponse> Put(Domain.Entities.PlannedMaintenanceTask PlannedMaintenanceTask);
        Task<RemovePlannedMaintenanceTaskResponse> Remove(string id);
    }
}
