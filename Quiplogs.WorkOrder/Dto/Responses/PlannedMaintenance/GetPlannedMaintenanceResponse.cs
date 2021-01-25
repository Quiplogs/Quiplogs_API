using System.Collections.Generic;
using Quiplogs.Core.Dto;
using Quiplogs.Core.Interfaces;

namespace Quiplogs.WorkOrder.Dto.Responses.PlannedMaintenance
{
    public class GetPlannedMaintenanceResponse : ServiceResponseMessage
    {
        public Domain.Entities.PlannedMaintenanceEntity PlannedMaintenance { get; }
        public IEnumerable<Error> Errors { get; }

        public GetPlannedMaintenanceResponse(IEnumerable<Error> errors, bool success = false, string message = null) : base(success, message)
        {
            Errors = errors;
        }

        public GetPlannedMaintenanceResponse(Domain.Entities.PlannedMaintenanceEntity plannedMaintenance, bool success = false, string message = null) : base(success, message)
        {
            PlannedMaintenance = plannedMaintenance;
        }
    }
}