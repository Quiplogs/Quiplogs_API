using Api.Core.Dto;
using Api.Core.Interfaces;
using System.Collections.Generic;

namespace Quiplogs.WorkOrder.Dto.Responses.WorkOrderPart
{
    public class RemoveWorkOrderPartResponse : ServiceResponseMessage
    {
        public string Description { get; }
        public IEnumerable<Error> Errors { get; }

        public RemoveWorkOrderPartResponse(IEnumerable<Error> errors, bool success = false, string message = null) : base(success, message)
        {
            Errors = errors;
        }

        public RemoveWorkOrderPartResponse(string description, bool success = false, string message = null) : base(success, message)
        {
            Description = description;
        }
    }
}
