using System.Collections.Generic;
using Quiplogs.Core.Dto;
using Quiplogs.Core.Dto.Repositories;

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
