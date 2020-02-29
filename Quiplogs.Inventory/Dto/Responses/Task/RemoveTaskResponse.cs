using Api.Core.Dto;
using Api.Core.Interfaces;
using System.Collections.Generic;

namespace Quiplogs.Inventory.Dto.Responses.Task
{
    public class RemoveTaskResponse : ServiceResponseMessage
    {
        public string Description { get; }
        public IEnumerable<Error> Errors { get; }

        public RemoveTaskResponse(IEnumerable<Error> errors, bool success = false, string message = null) : base(success, message)
        {
            Errors = errors;
        }

        public RemoveTaskResponse(string description, bool success = false, string message = null) : base(success, message)
        {
            Description = description;
        }
    }
}
