using Api.Core.Interfaces;
using Quiplogs.WorkOrder.Dto.Responses.PlannedMaintenancePart;
using System;

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
