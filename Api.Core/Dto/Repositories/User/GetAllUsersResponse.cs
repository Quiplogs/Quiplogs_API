using Api.Core.Domain.Entities;
using System.Collections.Generic;

namespace Api.Core.Dto.Repositories.User
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
