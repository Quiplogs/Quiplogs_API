using Api.Core.Interfaces;
using Quiplogs.WorkOrder.Dto.Responses.PlannedMaintenanceTask;

namespace Quiplogs.WorkOrder.Dto.Requests.PlannedMaintenanceTask
{
    public class ListPlannedMaintenanceTaskRequest : IRequest<ListPlannedMaintenanceTaskResponse>
    {
        public string PlannedMaintenanceId { get; }
        public ListPlannedMaintenanceTaskRequest(string plannedMaintenanceId)
        {
            PlannedMaintenanceId = plannedMaintenanceId;
        }
    }
}
