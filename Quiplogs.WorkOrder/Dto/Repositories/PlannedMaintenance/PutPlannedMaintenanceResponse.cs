using Api.Core.Dto;
using Api.Core.Dto.Responses;
using System.Collections.Generic;

namespace Quiplogs.WorkOrder.Dto.Repositories.PlannedMaintenance
{
    public class PutPlannedMaintenanceResponse : BaseResponse
    {
        public Domain.Entities.PlannedMaintenance PlannedMaintenance { get; set; }

        public PutPlannedMaintenanceResponse(Domain.Entities.PlannedMaintenance plannedMaintenance, bool success = false, IEnumerable<Error> errors = null) : base(success, errors)
        {
            PlannedMaintenance = plannedMaintenance;
        }
    }
}
