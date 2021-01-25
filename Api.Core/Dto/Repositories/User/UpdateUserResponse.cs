using System.Collections.Generic;
using Quiplogs.Core.Domain.Entities;

namespace Quiplogs.Core.Dto.Repositories.User
{
    public class UpdateUserResponse : BaseRepositoryResponse
    {
        public AppUser User { get; set; }

        public UpdateUserResponse(AppUser user, bool success = false, IEnumerable<Error> errors = null) : base(success, errors)
        {
            User = user;
        }
    }
}
