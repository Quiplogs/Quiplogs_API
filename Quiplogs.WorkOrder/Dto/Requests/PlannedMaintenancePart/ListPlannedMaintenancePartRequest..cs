using Api.Core.Interfaces;
using Quiplogs.WorkOrder.Dto.Responses.PlannedMaintenancePart;

namespace Quiplogs.WorkOrder.Dto.Requests.PlannedMaintenancePart
{
    public class ListPlannedMaintenancePartRequest : IRequest<ListPlannedMaintenancePartResponse>
    {
        public string PlannedMaintenanceId { get; }
        public int PageNumber { get; }
        public ListPlannedMaintenancePartRequest(string plannedMaintenanceId, int pageNumber)
        {
            PlannedMaintenanceId = plannedMaintenanceId;
            PageNumber = pageNumber;
        }
    }
}
