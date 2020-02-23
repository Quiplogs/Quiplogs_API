using Api.Core.Dto;
using Api.Core.Interfaces;
using System.Collections.Generic;

namespace Quiplogs.WorkOrder.Dto.Responses.WorkOrder
{
    public class GetWorkOrderResponse : WorkOrderResponseMessage
    {
        public Domain.Entities.WorkOrder WorkOrder { get; }
        public IEnumerable<Error> Errors { get; }

        public GetWorkOrderResponse(IEnumerable<Error> errors, bool success = false, string message = null) : base(success, message)
        {
            Errors = errors;
        }

        public GetWorkOrderResponse(Domain.Entities.WorkOrder workOrder, bool success = false, string message = null) : base(success, message)
        {
            WorkOrder = workOrder;
        }
    }
}
