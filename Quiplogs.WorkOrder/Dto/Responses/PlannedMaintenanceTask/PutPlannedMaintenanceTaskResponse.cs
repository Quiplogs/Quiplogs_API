using System.Collections.Generic;
using Quiplogs.Core.Dto;
using Quiplogs.Core.Interfaces;

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
