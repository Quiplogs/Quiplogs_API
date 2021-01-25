using System.Collections.Generic;
using Quiplogs.Core.Dto;
using Quiplogs.Core.Interfaces;

namespace Quiplogs.WorkOrder.Dto.Responses.WorkOrder
{
    public class GetWorkOrderResponse : ServiceResponseMessage
    {
        public Domain.Entities.WorkOrderEntity WorkOrder { get; }
        public IEnumerable<Error> Errors { get; }

        public GetWorkOrderResponse(IEnumerable<Error> errors, bool success = false, string message = null) : base(success, message)
        {
            Errors = errors;
        }

        public GetWorkOrderResponse(Domain.Entities.WorkOrderEntity workOrder, bool success = false, string message = null) : base(success, message)
        {
            WorkOrder = workOrder;
        }
    }
}
