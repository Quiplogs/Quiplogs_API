using System.Collections.Generic;
using Quiplogs.Core.Domain.Entities;
using Quiplogs.Core.Interfaces;

namespace Quiplogs.Core.Dto.Responses.User
{
    public class FetchUsersResponse : ServiceResponseMessage
    {
        public List<AppUser> Users { get; }
        public IEnumerable<Error> Errors { get; }

        public FetchUsersResponse(IEnumerable<Error> errors, bool success = false, string message = null) : base(success, message)
        {
            Errors = errors;
        }

        public FetchUsersResponse(List<AppUser> users, bool success = false, string message = null) : base(success, message)
        {
            Users = users;
        }
    }
}
