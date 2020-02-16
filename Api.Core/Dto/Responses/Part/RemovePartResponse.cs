using Api.Core.Interfaces;
using System.Collections.Generic;

namespace Api.Core.Dto.Responses.Part
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
