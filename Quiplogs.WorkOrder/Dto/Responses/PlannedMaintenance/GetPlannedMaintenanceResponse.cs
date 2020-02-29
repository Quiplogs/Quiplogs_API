using Api.Core.Dto;
using Api.Core.Interfaces;
using System.Collections.Generic;

namespace Quiplogs.WorkOrder.Dto.Responses.PlannedMaintenance
{
    public class GetPlannedMaintenanceResponse : ServiceResponseMessage
    {
        public Domain.Entities.PlannedMaintenance PlannedMaintenance { get; }
        public IEnumerable<Error> Errors { get; }

        public GetPlannedMaintenanceResponse(IEnumerable<Error> errors, bool success = false, string message = null) : base(success, message)
        {
            Errors = errors;
        }

        public GetPlannedMaintenanceResponse(Domain.Entities.PlannedMaintenance plannedMaintenance, bool success = false, string message = null) : base(success, message)
        {
            PlannedMaintenance = plannedMaintenance;
        }
    }
}