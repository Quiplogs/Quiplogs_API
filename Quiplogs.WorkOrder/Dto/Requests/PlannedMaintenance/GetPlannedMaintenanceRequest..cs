using Api.Core.Interfaces;
using Quiplogs.WorkOrder.Dto.Responses.PlannedMaintenance;
using System;

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
