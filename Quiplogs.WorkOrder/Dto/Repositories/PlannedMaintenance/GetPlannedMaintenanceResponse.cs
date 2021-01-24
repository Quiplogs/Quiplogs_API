using Api.Core.Dto;
using Api.Core.Dto.Repositories;
using System.Collections.Generic;

namespace Quiplogs.WorkOrder.Dto.Repositories.PlannedMaintenance
{
    public class GetPlannedMaintenanceResponse : BaseRepositoryResponse
    {
        public Domain.Entities.PlannedMaintenanceEntity PlannedMaintenance { get; set; }

        public GetPlannedMaintenanceResponse(Domain.Entities.PlannedMaintenanceEntity plannedMaintenance, bool success = false, IEnumerable<Error> errors = null) : base(success, errors)
        {
            PlannedMaintenance = plannedMaintenance;
        }
    }

}
