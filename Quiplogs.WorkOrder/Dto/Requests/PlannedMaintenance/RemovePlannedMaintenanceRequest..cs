using Api.Core.Interfaces;
using Quiplogs.WorkOrder.Dto.Responses.PlannedMaintenance;
using System;

namespace Quiplogs.WorkOrder.Dto.Requests.PlannedMaintenance
{
    public class RemovePlannedMaintenanceRequest : IRequest<RemovePlannedMaintenanceResponse>
    {
        public Guid Id { get; }
        public RemovePlannedMaintenanceRequest(Guid id)
        {
            Id = id;
        }
    }
}
