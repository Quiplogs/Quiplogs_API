using System.Collections.Generic;
using Quiplogs.Core.Domain;
using Quiplogs.Core.Domain.Entities;
using Quiplogs.Core.Interfaces;

namespace Quiplogs.Core.Dto.Responses.User
{
    public class FetchUsersResponse : ServiceResponseMessage
    {
        public PagedResult<AppUser> PagedResult { get; }
        public IEnumerable<Error> Errors { get; }

        public FetchUsersResponse(IEnumerable<Error> errors, bool success = false, string message = null) : base(success, message)
        {
            Errors = errors;
        }

        public FetchUsersResponse(PagedResult<AppUser> pagedResult, bool success = false, string message = null) : base(success, message)
        {
            PagedResult = pagedResult;
        }
    }
}
