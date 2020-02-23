using Api.Core.Domain.Entities;
using Api.Core.Interfaces;
using System.Collections.Generic;

namespace Api.Core.Dto.Responses.User
{
    public class GetUserResponse : WorkOrderResponseMessage
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
