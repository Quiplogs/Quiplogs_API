using Api.Core.Dto;
using Api.Core.Dto.Responses;
using System.Collections.Generic;

namespace Quiplogs.WorkOrder.Dto.Repositories.PlannedMaintenancePart
{
    public class ListPlannedMaintenancePartResponse : BaseResponse
    {
        public List<Domain.Entities.PlannedMaintenancePart> PlannedMaintenanceParts { get; set; }

        public ListPlannedMaintenancePartResponse(List<Domain.Entities.PlannedMaintenancePart> plannedMaintenanceParts, bool success = false, IEnumerable<Error> errors = null) : base(success, errors)
        {
            PlannedMaintenanceParts = plannedMaintenanceParts;
        }
    }
}
