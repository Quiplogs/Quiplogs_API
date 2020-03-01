using Api.Core.Dto;
using Api.Core.Interfaces;
using System.Collections.Generic;

namespace Quiplogs.WorkOrder.Dto.Responses.WorkOrderTask
{
    public class RemoveWorkOrderTaskResponse : ServiceResponseMessage
    {
        public string Description { get; }
        public IEnumerable<Error> Errors { get; }

        public RemoveWorkOrderTaskResponse(IEnumerable<Error> errors, bool success = false, string message = null) : base(success, message)
        {
            Errors = errors;
        }

        public RemoveWorkOrderTaskResponse(string description, bool success = false, string message = null) : base(success, message)
        {
            Description = description;
        }
    }
}
