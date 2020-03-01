using Api.Core.Domain.Entities;
using Api.Core.Dto;
using Api.Core.Interfaces;
using System.Collections.Generic;

namespace Quiplogs.WorkOrder.Dto.Responses.PlannedMaintenanceTask
{
    public class ListPlannedMaintenanceTaskResponse : ServiceResponseMessage
    {
        public PagedResult<Domain.Entities.PlannedMaintenanceTask> PagedResult { get; }
        public IEnumerable<Error> Errors { get; }

        public ListPlannedMaintenanceTaskResponse(IEnumerable<Error> errors, bool success = false, string message = null) : base(success, message)
        {
            Errors = errors;
        }

        public ListPlannedMaintenanceTaskResponse(PagedResult<Domain.Entities.PlannedMaintenanceTask> pagedResult, bool success = false, string message = null) : base(success, message)
        {
            PagedResult = pagedResult;
        }
    }
}
