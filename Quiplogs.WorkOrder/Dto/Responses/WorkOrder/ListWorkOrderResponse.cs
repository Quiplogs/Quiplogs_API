using System.Collections.Generic;
using Quiplogs.Core.Domain;
using Quiplogs.Core.Dto;
using Quiplogs.Core.Interfaces;

namespace Quiplogs.WorkOrder.Dto.Responses.WorkOrder
{
    public class ListWorkOrderResponse : ServiceResponseMessage
    {
        public PagedResult<Domain.Entities.WorkOrderEntity> PagedResult { get; }
        public IEnumerable<Error> Errors { get; }

        public ListWorkOrderResponse(IEnumerable<Error> errors, bool success = false, string message = null) : base(success, message)
        {
            Errors = errors;
        }

        public ListWorkOrderResponse(PagedResult<Domain.Entities.WorkOrderEntity> pagedResult, bool success = false, string message = null) : base(success, message)
        {
            PagedResult = pagedResult;
        }
    }
}
