using System.Collections.Generic;
using Quiplogs.Core.Dto;
using Quiplogs.Core.Interfaces;

namespace Quiplogs.WorkOrder.Dto.Responses.WorkOrder
{
    public class RemoveWorkOrderResponse : ServiceResponseMessage
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
