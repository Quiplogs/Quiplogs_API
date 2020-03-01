using Api.Core.Interfaces;
using Quiplogs.WorkOrder.Dto.Responses.PlannedMaintenanceTask;

namespace Quiplogs.WorkOrder.Dto.Requests.PlannedMaintenanceTask
{
    public class PutPlannedMaintenanceTaskRequest : IRequest<PutPlannedMaintenanceTaskResponse>
    {
        public Domain.Entities.PlannedMaintenanceTask PlannedMaintenanceTask { get; }
        public PutPlannedMaintenanceTaskRequest(Domain.Entities.PlannedMaintenanceTask plannedMaintenanceTask)
        {
            PlannedMaintenanceTask = plannedMaintenanceTask;
        }
    }
}
