using Api.Core.Dto;
using Api.Core.Interfaces;
using System.Collections.Generic;

namespace Quiplogs.WorkOrder.Dto.Responses.WorkOrder
{
    public class PutWorkOrderResponse : ServiceResponseMessage
    {
        public Domain.Entities.WorkOrderEntity WorkOrder { get; }
        public IEnumerable<Error> Errors { get; }

        public PutWorkOrderResponse(IEnumerable<Error> errors, bool success = false, string message = null) : base(success, message)
        {
            Errors = errors;
        }

        public PutWorkOrderResponse(Domain.Entities.WorkOrderEntity workOrder, bool success = false, string message = null) : base(success, message)
        {
            WorkOrder = workOrder;
        }
    }
}
