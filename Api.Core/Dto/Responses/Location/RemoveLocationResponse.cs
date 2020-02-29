using Api.Core.Interfaces;
using System.Collections.Generic;

namespace Api.Core.Dto.Responses.Location
{
    public class RemoveLocationResponse : ServiceResponseMessage
    {
        public string Description { get; }
        public IEnumerable<Error> Errors { get; }

        public RemoveLocationResponse(IEnumerable<Error> errors, bool success = false, string message = null) : base(success, message)
        {
            Errors = errors;
        }

        public RemoveLocationResponse(string description, bool success = false, string message = null) : base(success, message)
        {
            Description = description;
        }
    }
}
