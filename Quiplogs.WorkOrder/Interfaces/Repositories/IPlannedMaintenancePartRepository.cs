using Quiplogs.WorkOrder.Dto.Repositories.PlannedMaintenancePart;
using System;
using System.Threading.Tasks;

namespace Quiplogs.WorkOrder.Interfaces.Repositories
{
    public interface IPlannedMaintenancePartRepository
    {
        Task<ListPlannedMaintenancePartResponse> List(Guid plannedMaintenanceId);
        int GetTotalRecords(Guid plannedMaintenanceId);
        Task<PutPlannedMaintenancePartResponse> Put(Domain.Entities.PlannedMaintenancePart PlannedMaintenancePart);
        Task<RemovePlannedMaintenancePartResponse> Remove(Guid id);
    }
}
