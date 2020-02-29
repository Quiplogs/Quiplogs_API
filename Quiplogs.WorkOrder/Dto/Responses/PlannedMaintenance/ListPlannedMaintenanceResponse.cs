using Api.Core.Domain.Entities;
using Api.Core.Dto;
using Api.Core.Interfaces;
using System.Collections.Generic;

namespace Quiplogs.WorkOrder.Dto.Responses.PlannedMaintenance
{
    public class ListPlannedMaintenanceResponse : ServiceResponseMessage
    {
        public PagedResult<Domain.Entities.PlannedMaintenance> PagedResult { get; }
        public IEnumerable<Error> Errors { get; }

        public ListPlannedMaintenanceResponse(IEnumerable<Error> errors, bool success = false, string message = null) : base(success, message)
        {
            Errors = errors;
        }

        public ListPlannedMaintenanceResponse(PagedResult<Domain.Entities.PlannedMaintenance> pagedResult, bool success = false, string message = null) : base(success, message)
        {
            PagedResult = pagedResult;
        }
    }
}
