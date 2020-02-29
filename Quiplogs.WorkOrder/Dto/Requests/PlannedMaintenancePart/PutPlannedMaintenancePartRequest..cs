using Api.Core.Interfaces;
using Quiplogs.WorkOrder.Dto.Responses.PlannedMaintenancePart;

namespace Quiplogs.WorkOrder.Dto.Requests.PlannedMaintenancePart
{
    public class PutPlannedMaintenancePartRequest : IRequest<PutPlannedMaintenancePartResponse>
    {
        public Domain.Entities.PlannedMaintenancePart PlannedMaintenancePart { get; }
        public PutPlannedMaintenancePartRequest(Domain.Entities.PlannedMaintenancePart plannedMaintenancePart)
        {
            PlannedMaintenancePart = plannedMaintenancePart;
        }
    }
}
