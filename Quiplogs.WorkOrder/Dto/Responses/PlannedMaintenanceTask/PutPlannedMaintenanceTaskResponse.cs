using Api.Core.Dto;
using Api.Core.Interfaces;
using System.Collections.Generic;

namespace Quiplogs.WorkOrder.Dto.Responses.PlannedMaintenanceTask
{
    public class PutPlannedMaintenanceTaskResponse : ServiceResponseMessage
    {
        public Domain.Entities.PlannedMaintenanceTask PlannedMaintenanceTask { get; }
        public IEnumerable<Error> Errors { get; }

        public PutPlannedMaintenanceTaskResponse(IEnumerable<Error> errors, bool success = false, string message = null) : base(success, message)
        {
            Errors = errors;
        }

        public PutPlannedMaintenanceTaskResponse(Domain.Entities.PlannedMaintenanceTask plannedMaintenanceTask, bool success = false, string message = null) : base(success, message)
        {
            PlannedMaintenanceTask = plannedMaintenanceTask;
        }
    }
}
