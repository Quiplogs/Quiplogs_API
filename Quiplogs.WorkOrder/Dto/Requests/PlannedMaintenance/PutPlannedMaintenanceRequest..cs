using Api.Core.Interfaces;
using Quiplogs.WorkOrder.Dto.Responses.PlannedMaintenance;

namespace Quiplogs.WorkOrder.Dto.Requests.PlannedMaintenance
{
    public class PutPlannedMaintenanceRequest : IRequest<PutPlannedMaintenanceResponse>
    {
        public Domain.Entities.PlannedMaintenanceEntity PlannedMaintenance { get; }
        public PutPlannedMaintenanceRequest(Domain.Entities.PlannedMaintenanceEntity plannedMaintenance)
        {
            PlannedMaintenance = plannedMaintenance;
        }
    }
}
