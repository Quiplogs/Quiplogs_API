using Api.Core.Interfaces;
using System.Collections.Generic;

namespace Api.Core.Dto.Responses.User
{
    public class RemoveUserResponse : WorkOrderResponseMessage
    {
        public string Name { get; }
        public IEnumerable<Error> Errors { get; }

        public RemoveUserResponse(IEnumerable<Error> errors, bool success = false, string message = null) : base(success, message)
        {
            Errors = errors;
        }

        public RemoveUserResponse(string name, bool success = false, string message = null) : base(success, message)
        {
            Name = name;
        }
    }
}
