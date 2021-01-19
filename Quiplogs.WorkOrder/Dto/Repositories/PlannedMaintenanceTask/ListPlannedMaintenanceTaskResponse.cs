using Api.Core.Dto;
using Api.Core.Dto.Responses;
using System.Collections.Generic;

namespace Quiplogs.WorkOrder.Dto.Repositories.PlannedMaintenanceTask
{
    public class ListPlannedMaintenanceTaskResponse : BaseRepositoryResponse
    {
        public List<Domain.Entities.PlannedMaintenanceTask> PlannedMaintenanceTasks { get; set; }

        public ListPlannedMaintenanceTaskResponse(List<Domain.Entities.PlannedMaintenanceTask> plannedMaintenanceTasks, bool success = false, IEnumerable<Error> errors = null) : base(success, errors)
        {
            PlannedMaintenanceTasks = plannedMaintenanceTasks;
        }
    }
}
