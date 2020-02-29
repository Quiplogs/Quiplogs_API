using Api.Core.Interfaces;
using Quiplogs.WorkOrder.Dto.Responses.WorkOrder;

namespace Quiplogs.WorkOrder.Dto.Requests.PlannedMaintenance
{
    public class PutPlannedMaintenanceRequest : IRequest<PutWorkOrderResponse>
    {
        public Domain.Entities.PlannedMaintenance PlannedMaintenance { get; }
        public PutPlannedMaintenanceRequest(Domain.Entities.PlannedMaintenance plannedMaintenance)
        {
            PlannedMaintenance = plannedMaintenance;
        }
    }
}
