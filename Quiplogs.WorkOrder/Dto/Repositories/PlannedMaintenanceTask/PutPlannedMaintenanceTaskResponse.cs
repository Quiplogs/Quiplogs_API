using Api.Core.Dto;
using Api.Core.Dto.Responses;
using System.Collections.Generic;

namespace Quiplogs.WorkOrder.Dto.Repositories.PlannedMaintenanceTask
{
    public class PutPlannedMaintenanceTaskResponse : BaseResponse
    {
        public Domain.Entities.PlannedMaintenanceTask PlannedMaintenanceTask { get; set; }

        public PutPlannedMaintenanceTaskResponse(Domain.Entities.PlannedMaintenanceTask plannedMaintenanceTask, bool success = false, IEnumerable<Error> errors = null) : base(success, errors)
        {
            PlannedMaintenanceTask = plannedMaintenanceTask;
        }
    }

}
