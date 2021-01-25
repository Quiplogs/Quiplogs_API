using Quiplogs.WorkOrder.Dto.Responses.PlannedMaintenanceTask;
using System;
using Quiplogs.Core.Interfaces;

namespace Quiplogs.WorkOrder.Dto.Requests.PlannedMaintenanceTask
{
    public class ListPlannedMaintenanceTaskRequest : IRequest<ListPlannedMaintenanceTaskResponse>
    {
        public Guid PlannedMaintenanceId { get; }
        public ListPlannedMaintenanceTaskRequest(Guid plannedMaintenanceId)
        {
            PlannedMaintenanceId = plannedMaintenanceId;
        }
    }
}
