using System.Collections.Generic;
using Quiplogs.Core.Dto;
using Quiplogs.Core.Interfaces;

namespace Quiplogs.WorkOrder.Dto.Responses.PlannedMaintenancePart
{
    public class ListPlannedMaintenancePartResponse : ServiceResponseMessage
    {
        public List<Domain.Entities.PlannedMaintenancePart> PlannedMaintenanceParts { get; }
        public IEnumerable<Error> Errors { get; }

        public ListPlannedMaintenancePartResponse(IEnumerable<Error> errors, bool success = false, string message = null) : base(success, message)
        {
            Errors = errors;
        }

        public ListPlannedMaintenancePartResponse(List<Domain.Entities.PlannedMaintenancePart> plannedMaintenanceParts, bool success = false, string message = null) : base(success, message)
        {
            PlannedMaintenanceParts = plannedMaintenanceParts;
        }
    }
}
