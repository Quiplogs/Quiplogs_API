using Quiplogs.Core.Domain;
using Quiplogs.Core.Domain.Entities;
using System.Collections.Generic;

namespace Quiplogs.Core.Dto.Repositories.User
{
    public class PagedUserResponse : BaseRepositoryResponse
    {
        public PagedResult<AppUser> PagedResult { get; set; }

        public PagedUserResponse(PagedResult<AppUser> pagedResult, bool success = false, IEnumerable<Error> errors = null) : base(success, errors)
        {
            PagedResult = pagedResult;
        }
    }
}
