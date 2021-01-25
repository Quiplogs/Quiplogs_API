using Quiplogs.WorkOrder.Dto.Responses.PlannedMaintenancePart;
using System;
using Quiplogs.Core.Interfaces;

namespace Quiplogs.WorkOrder.Dto.Requests.PlannedMaintenancePart
{
    public class ListPlannedMaintenancePartRequest : IRequest<ListPlannedMaintenancePartResponse>
    {
        public Guid PlannedMaintenanceId { get; }

        public ListPlannedMaintenancePartRequest(Guid plannedMaintenanceId)
        {
            PlannedMaintenanceId = plannedMaintenanceId;
        }
    }
}
