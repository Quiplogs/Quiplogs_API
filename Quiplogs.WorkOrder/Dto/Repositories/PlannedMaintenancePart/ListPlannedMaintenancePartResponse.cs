using Api.Core.Dto;
using Api.Core.Dto.Repositories;
using System.Collections.Generic;

namespace Quiplogs.WorkOrder.Dto.Repositories.PlannedMaintenancePart
{
    public class ListPlannedMaintenancePartResponse : BaseRepositoryResponse
    {
        public List<Domain.Entities.PlannedMaintenancePart> PlannedMaintenanceParts { get; set; }

        public ListPlannedMaintenancePartResponse(List<Domain.Entities.PlannedMaintenancePart> plannedMaintenanceParts, bool success = false, IEnumerable<Error> errors = null) : base(success, errors)
        {
            PlannedMaintenanceParts = plannedMaintenanceParts;
        }
    }
}
