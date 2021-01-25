using System.Collections.Generic;
using Quiplogs.Core.Interfaces;

namespace Quiplogs.Core.Dto.Responses.User
{
    public class RemoveUserResponse : ServiceResponseMessage
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
