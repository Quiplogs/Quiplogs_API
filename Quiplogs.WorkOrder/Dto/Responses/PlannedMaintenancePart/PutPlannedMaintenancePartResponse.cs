using Api.Core.Dto;
using Api.Core.Interfaces;
using System.Collections.Generic;

namespace Quiplogs.WorkOrder.Dto.Responses.PlannedMaintenancePart
{
    public class PutPlannedMaintenancePartResponse : ServiceResponseMessage
    {
        public Domain.Entities.PlannedMaintenancePart PlannedMaintenancePart { get; }
        public IEnumerable<Error> Errors { get; }

        public PutPlannedMaintenancePartResponse(IEnumerable<Error> errors, bool success = false, string message = null) : base(success, message)
        {
            Errors = errors;
        }

        public PutPlannedMaintenancePartResponse(Domain.Entities.PlannedMaintenancePart plannedMaintenancePart, bool success = false, string message = null) : base(success, message)
        {
            PlannedMaintenancePart = plannedMaintenancePart;
        }
    }
}
