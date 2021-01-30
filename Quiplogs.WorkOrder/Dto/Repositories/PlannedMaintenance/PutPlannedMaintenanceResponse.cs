using System.Collections.Generic;
using Quiplogs.Core.Dto;
using Quiplogs.Core.Dto.Repositories;

namespace Quiplogs.WorkOrder.Dto.Repositories.PlannedMaintenance
{
    public class PutPlannedMaintenanceResponse : BaseRepositoryResponse
    {
        public Domain.Entities.PlannedMaintenance PlannedMaintenance { get; set; }

        public PutPlannedMaintenanceResponse(Domain.Entities.PlannedMaintenance plannedMaintenance, bool success = false, IEnumerable<Error> errors = null) : base(success, errors)
        {
            PlannedMaintenance = plannedMaintenance;
        }
    }
}
