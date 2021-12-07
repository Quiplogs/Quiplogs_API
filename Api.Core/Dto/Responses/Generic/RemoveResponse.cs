using System.Collections.Generic;
using Quiplogs.Core.Interfaces;

namespace Quiplogs.Core.Dto.Responses.Generic
{
    public class RemoveResponse : ServiceResponseMessage
    {
        public string Description { get; }
        public IEnumerable<Error> Errors { get; }

        public RemoveResponse(IEnumerable<Error> errors, bool success = false, string message = null) : base(success, message)
        {
            Errors = errors;
        }

        public RemoveResponse(string description, bool success = false, string message = null) : base(success, message)
        {
            Description = description;
        }
    }
}
