using Api.Core.Interfaces;
using Quiplogs.WorkOrder.Dto.Responses.PlannedMaintenancePart;
using System;

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
