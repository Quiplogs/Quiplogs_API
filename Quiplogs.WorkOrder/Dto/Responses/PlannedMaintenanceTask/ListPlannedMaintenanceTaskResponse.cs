using System.Collections.Generic;
using Quiplogs.Core.Dto;
using Quiplogs.Core.Interfaces;

namespace Quiplogs.WorkOrder.Dto.Responses.PlannedMaintenanceTask
{
    public class ListPlannedMaintenanceTaskResponse : ServiceResponseMessage
    {
        public List<Domain.Entities.PlannedMaintenanceTask> PlannedMaintenanceTasks { get; }
        public IEnumerable<Error> Errors { get; }

        public ListPlannedMaintenanceTaskResponse(IEnumerable<Error> errors, bool success = false, string message = null) : base(success, message)
        {
            Errors = errors;
        }

        public ListPlannedMaintenanceTaskResponse(List<Domain.Entities.PlannedMaintenanceTask> plannedMaintenanceTasks, bool success = false, string message = null) : base(success, message)
        {
            PlannedMaintenanceTasks = plannedMaintenanceTasks;
        }
    }
}
