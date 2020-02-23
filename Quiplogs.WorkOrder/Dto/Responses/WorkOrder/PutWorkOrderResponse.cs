using Api.Core.Dto;
using Api.Core.Interfaces;
using System.Collections.Generic;

namespace Quiplogs.WorkOrder.Dto.Responses.WorkOrder
{
    public class PutWorkOrderResponse : WorkOrderResponseMessage
    {
        public Domain.Entities.WorkOrder WorkOrder { get; }
        public IEnumerable<Error> Errors { get; }

        public PutWorkOrderResponse(IEnumerable<Error> errors, bool success = false, string message = null) : base(success, message)
        {
            Errors = errors;
        }

        public PutWorkOrderResponse(Domain.Entities.WorkOrder workOrder, bool success = false, string message = null) : base(success, message)
        {
            WorkOrder = workOrder;
        }
    }
}
