using Api.Core.Domain.Entities;
using Api.Core.Interfaces;
using System.Collections.Generic;

namespace Api.Core.Dto.Responses.User
{
    public class FetchUsersResponse : WorkOrderResponseMessage
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
