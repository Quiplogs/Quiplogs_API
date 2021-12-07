using System.Collections.Generic;
using Quiplogs.Core.Domain.Entities;

namespace Quiplogs.Core.Dto.Repositories.User
{
    public class GetAllUsersResponse : BaseRepositoryResponse
    {
        public List<AppUser> Users { get; set; }

        public GetAllUsersResponse(List<AppUser> users, bool success = false, IEnumerable<Error> errors = null) : base(success, errors)
        {
            Users = users;
        }
    }
}
