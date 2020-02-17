using Api.Core.Interfaces;
using System.Collections.Generic;

namespace Api.Core.Dto.Responses.Service
{
    public class RemoveServiceResponse : ServiceResponseMessage
    {
        public string Description { get; }
        public IEnumerable<Error> Errors { get; }

        public RemoveServiceResponse(IEnumerable<Error> errors, bool success = false, string message = null) : base(success, message)
        {
            Errors = errors;
        }

        public RemoveServiceResponse(string description, bool success = false, string message = null) : base(success, message)
        {
            Description = description;
        }
    }
}
