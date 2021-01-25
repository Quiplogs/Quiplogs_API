using System.Collections.Generic;
using Quiplogs.Core.Domain;
using Quiplogs.Core.Dto;
using Quiplogs.Core.Interfaces;

namespace Quiplogs.WorkOrder.Dto.Responses.WorkOrderPart
{
    public class ListWorkOrderPartResponse : ServiceResponseMessage
    {
        public PagedResult<Domain.Entities.WorkOrderPart> PagedResult { get; }
        public IEnumerable<Error> Errors { get; }

        public ListWorkOrderPartResponse(IEnumerable<Error> errors, bool success = false, string message = null) : base(success, message)
        {
            Errors = errors;
        }

        public ListWorkOrderPartResponse(PagedResult<Domain.Entities.WorkOrderPart> pagedResult, bool success = false, string message = null) : base(success, message)
        {
            PagedResult = pagedResult;
        }
    }
}
