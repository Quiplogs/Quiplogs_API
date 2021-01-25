using System.Collections.Generic;
using Quiplogs.Core.Dto;
using Quiplogs.Core.Dto.Repositories;

namespace Quiplogs.WorkOrder.Dto.Repositories.PlannedMaintenancePart
{
    public class PutPlannedMaintenancePartResponse : BaseRepositoryResponse
    {
        public Domain.Entities.PlannedMaintenancePart PlannedMaintenancePart { get; set; }

        public PutPlannedMaintenancePartResponse(Domain.Entities.PlannedMaintenancePart plannedMaintenancePart, bool success = false, IEnumerable<Error> errors = null) : base(success, errors)
        {
            PlannedMaintenancePart = plannedMaintenancePart;
        }
    }
}
