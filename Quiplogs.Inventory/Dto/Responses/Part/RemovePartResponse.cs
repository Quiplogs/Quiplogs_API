using System.Collections.Generic;
using Quiplogs.Core.Dto;
using Quiplogs.Core.Interfaces;

namespace Quiplogs.Inventory.Dto.Responses.Part
{
    public class RemovePartResponse : ServiceResponseMessage
    {
        public string Description { get; }
        public IEnumerable<Error> Errors { get; }

        public RemovePartResponse(IEnumerable<Error> errors, bool success = false, string message = null) : base(success, message)
        {
            Errors = errors;
        }

        public RemovePartResponse(string description, bool success = false, string message = null) : base(success, message)
        {
            Description = description;
        }
    }
}
