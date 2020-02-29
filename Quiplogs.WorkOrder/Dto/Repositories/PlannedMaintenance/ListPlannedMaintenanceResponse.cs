using Api.Core.Dto;
using Api.Core.Dto.Responses;
using System.Collections.Generic;

namespace Quiplogs.WorkOrder.Dto.Repositories.PlannedMaintenance
{
    public class ListPlannedMaintenanceResponse : BaseResponse
    {
        public List<Domain.Entities.PlannedMaintenanceEntity> PlannedMaintenances { get; set; }

        public ListPlannedMaintenanceResponse(List<Domain.Entities.PlannedMaintenanceEntity> plannedMaintenances, bool success = false, IEnumerable<Error> errors = null) : base(success, errors)
        {
            PlannedMaintenances = plannedMaintenances;
        }
    }
}
