using Quiplogs.WorkOrder.Dto.Responses.PlannedMaintenancePart;
using System;
using Quiplogs.Core.Interfaces;

namespace Quiplogs.WorkOrder.Dto.Requests.PlannedMaintenancePart
{
    public class RemovePlannedMaintenancePartRequest : IRequest<RemovePlannedMaintenancePartResponse>
    {
        public Guid Id { get; }
        public RemovePlannedMaintenancePartRequest(Guid id)
        {
            Id = id;
        }
    }
}
