using Api.Core.Domain.Entities;
using Api.Core.Dto;
using Api.Core.Interfaces;
using System.Collections.Generic;

namespace Quiplogs.WorkOrder.Dto.Responses.WorkOrderTask
{
    public class ListWorkOrderTaskResponse : ServiceResponseMessage
    {
        public PagedResult<Domain.Entities.WorkOrderTask> PagedResult { get; }
        public IEnumerable<Error> Errors { get; }

        public ListWorkOrderTaskResponse(IEnumerable<Error> errors, bool success = false, string message = null) : base(success, message)
        {
            Errors = errors;
        }

        public ListWorkOrderTaskResponse(PagedResult<Domain.Entities.WorkOrderTask> pagedResult, bool success = false, string message = null) : base(success, message)
        {
            PagedResult = pagedResult;
        }
    }
}
