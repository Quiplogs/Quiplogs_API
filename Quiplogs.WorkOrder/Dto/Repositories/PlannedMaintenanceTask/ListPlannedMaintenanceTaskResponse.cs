using System.Collections.Generic;
using Quiplogs.Core.Dto;
using Quiplogs.Core.Dto.Repositories;

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
