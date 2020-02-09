using Api.Core.Dto.Responses;
using System.Collections.Generic;

namespace Api.Core.Dto.Repositories.User
{
    public class RemoveUserResponse : BaseResponse
    {
        public string UserName { get; set; }

        public RemoveUserResponse(string userName, bool success = false, IEnumerable<Error> errors = null) : base(success, errors)
        {
            UserName = userName;
        }
    }
}
