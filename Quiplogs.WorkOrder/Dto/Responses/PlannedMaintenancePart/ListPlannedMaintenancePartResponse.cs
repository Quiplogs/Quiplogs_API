using Api.Core.Domain.Entities;
using Api.Core.Dto;
using Api.Core.Interfaces;
using System.Collections.Generic;

namespace Quiplogs.WorkOrder.Dto.Responses.PlannedMaintenancePart
{
    public class ListPlannedMaintenancePartResponse : ServiceResponseMessage
    {
        public PagedResult<Domain.Entities.PlannedMaintenancePart> PagedResult { get; }
        public IEnumerable<Error> Errors { get; }

        public ListPlannedMaintenancePartResponse(IEnumerable<Error> errors, bool success = false, string message = null) : base(success, message)
        {
            Errors = errors;
        }

        public ListPlannedMaintenancePartResponse(PagedResult<Domain.Entities.PlannedMaintenancePart> pagedResult, bool success = false, string message = null) : base(success, message)
        {
            PagedResult = pagedResult;
        }
    }
}
