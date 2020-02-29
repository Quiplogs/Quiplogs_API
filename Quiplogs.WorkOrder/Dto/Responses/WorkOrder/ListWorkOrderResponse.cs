using Api.Core.Domain.Entities;
using Api.Core.Dto;
using Api.Core.Interfaces;
using System.Collections.Generic;

namespace Quiplogs.WorkOrder.Dto.Responses.WorkOrder
{
    public class ListWorkOrderResponse : WorkOrderResponseMessage
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
