using System.Collections.Generic;

namespace Api.Core.Dto.Repositories.User
{
    public class RemoveUserResponse : BaseRepositoryResponse
    {
        public string UserName { get; set; }

        public RemoveUserResponse(string userName, bool success = false, IEnumerable<Error> errors = null) : base(success, errors)
        {
            UserName = userName;
        }
    }
}
