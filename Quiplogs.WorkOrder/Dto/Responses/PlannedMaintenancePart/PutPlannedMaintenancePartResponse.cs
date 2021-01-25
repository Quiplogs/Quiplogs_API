using System.Collections.Generic;
using Quiplogs.Core.Dto;
using Quiplogs.Core.Interfaces;

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
