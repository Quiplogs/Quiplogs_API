using Api.Core.Dto;
using Api.Core.Interfaces;
using System.Collections.Generic;

namespace Quiplogs.WorkOrder.Dto.Responses.WorkOrder
{
    public class RemoveWorkOrderResponse : WorkOrderResponseMessage
    {
        public string Description { get; }
        public IEnumerable<Error> Errors { get; }

        public RemoveWorkOrderResponse(IEnumerable<Error> errors, bool success = false, string message = null) : base(success, message)
        {
            Errors = errors;
        }

        public RemoveWorkOrderResponse(string description, bool success = false, string message = null) : base(success, message)
        {
            Description = description;
        }
    }
}
