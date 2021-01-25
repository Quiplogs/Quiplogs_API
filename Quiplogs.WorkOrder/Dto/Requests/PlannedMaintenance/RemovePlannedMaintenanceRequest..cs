using Quiplogs.WorkOrder.Dto.Responses.PlannedMaintenance;
using System;
using Quiplogs.Core.Interfaces;

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
