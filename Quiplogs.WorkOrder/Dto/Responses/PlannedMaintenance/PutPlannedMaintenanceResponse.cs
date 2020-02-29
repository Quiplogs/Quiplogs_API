using Api.Core.Dto;
using Api.Core.Interfaces;
using System.Collections.Generic;

namespace Quiplogs.WorkOrder.Dto.Responses.PlannedMaintenance
{
    public class PutPlannedMaintenanceResponse : ServiceResponseMessage
    {
        public Domain.Entities.PlannedMaintenanceEntity PlannedMaintenance { get; }
        public IEnumerable<Error> Errors { get; }

        public PutPlannedMaintenanceResponse(IEnumerable<Error> errors, bool success = false, string message = null) : base(success, message)
        {
            Errors = errors;
        }

        public PutPlannedMaintenanceResponse(Domain.Entities.PlannedMaintenanceEntity plannedMaintenance, bool success = false, string message = null) : base(success, message)
        {
            PlannedMaintenance = plannedMaintenance;
        }
    }
}
