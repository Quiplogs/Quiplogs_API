using Api.Core.Interfaces;
using Quiplogs.WorkOrder.Dto.Responses.PlannedMaintenanceTask;

namespace Quiplogs.WorkOrder.Dto.Requests.PlannedMaintenanceTask
{
    public class ListPlannedMaintenanceTaskRequest : IRequest<ListPlannedMaintenanceTaskResponse>
    {
        public string PlannedMaintenanceId { get; }
        public int PageNumber { get; }
        public ListPlannedMaintenanceTaskRequest(string plannedMaintenanceId, int pageNumber)
        {
            PlannedMaintenanceId = plannedMaintenanceId;
            PageNumber = pageNumber;
        }
    }
}
