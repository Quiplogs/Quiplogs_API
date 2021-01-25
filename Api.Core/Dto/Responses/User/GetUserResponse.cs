using System.Collections.Generic;
using Quiplogs.Core.Domain.Entities;
using Quiplogs.Core.Interfaces;

namespace Quiplogs.Core.Dto.Responses.User
{
    public class GetUserResponse : ServiceResponseMessage
    {
        public AppUser User { get; }
        public IEnumerable<Error> Errors { get; }

        public GetUserResponse(IEnumerable<Error> errors, bool success = false, string message = null) : base(success, message)
        {
            Errors = errors;
        }

        public GetUserResponse(AppUser user, bool success = false, string message = null) : base(success, message)
        {
            User = user;
        }
    }
}
