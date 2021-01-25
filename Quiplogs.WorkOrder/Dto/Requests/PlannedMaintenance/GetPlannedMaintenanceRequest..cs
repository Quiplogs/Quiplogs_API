using Quiplogs.WorkOrder.Dto.Responses.PlannedMaintenance;
using System;
using Quiplogs.Core.Interfaces;

namespace Quiplogs.WorkOrder.Dto.Requests.PlannedMaintenance
{
    public class GetPlannedMaintenanceRequest : IRequest<GetPlannedMaintenanceResponse>
    {
        public Guid Id { get; }
        public GetPlannedMaintenanceRequest(Guid id)
        {
            Id = id;
        }
    }
}
