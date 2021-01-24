using Quiplogs.WorkOrder.Dto.Repositories.PlannedMaintenanceTask;
using System;
using System.Threading.Tasks;

namespace Quiplogs.WorkOrder.Interfaces.Repositories
{
    public interface IPlannedMaintenanceTaskRepository
    {
        Task<ListPlannedMaintenanceTaskResponse> List(Guid plannedMaintenanceId);
        int GetTotalRecords(Guid plannedMaintenanceId);
        Task<PutPlannedMaintenanceTaskResponse> Put(Domain.Entities.PlannedMaintenanceTask PlannedMaintenanceTask);
        Task<RemovePlannedMaintenanceTaskResponse> Remove(Guid id);
    }
}
