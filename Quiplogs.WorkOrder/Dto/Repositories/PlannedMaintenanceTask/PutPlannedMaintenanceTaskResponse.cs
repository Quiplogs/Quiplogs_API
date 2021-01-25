using System.Collections.Generic;
using Quiplogs.Core.Dto;
using Quiplogs.Core.Dto.Repositories;

namespace Quiplogs.WorkOrder.Dto.Repositories.PlannedMaintenanceTask
{
    public class PutPlannedMaintenanceTaskResponse : BaseRepositoryResponse
    {
        public Domain.Entities.PlannedMaintenanceTask PlannedMaintenanceTask { get; set; }

        public PutPlannedMaintenanceTaskResponse(Domain.Entities.PlannedMaintenanceTask plannedMaintenanceTask, bool success = false, IEnumerable<Error> errors = null) : base(success, errors)
        {
            PlannedMaintenanceTask = plannedMaintenanceTask;
        }
    }

}
