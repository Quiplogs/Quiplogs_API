using System.Collections.Generic;
using Quiplogs.Core.Domain;
using Quiplogs.Core.Dto;
using Quiplogs.Core.Interfaces;

namespace Quiplogs.WorkOrder.Dto.Responses.PlannedMaintenance
{
    public class ListPlannedMaintenanceResponse : ServiceResponseMessage
    {
        public PagedResult<Domain.Entities.PlannedMaintenanceEntity> PagedResult { get; }
        public IEnumerable<Error> Errors { get; }

        public ListPlannedMaintenanceResponse(IEnumerable<Error> errors, bool success = false, string message = null) : base(success, message)
        {
            Errors = errors;
        }

        public ListPlannedMaintenanceResponse(PagedResult<Domain.Entities.PlannedMaintenanceEntity> pagedResult, bool success = false, string message = null) : base(success, message)
        {
            PagedResult = pagedResult;
        }
    }
}
