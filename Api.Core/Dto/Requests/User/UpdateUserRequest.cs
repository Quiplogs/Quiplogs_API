using Quiplogs.Core.Domain.Entities;
using Quiplogs.Core.Dto.Responses.User;
using Quiplogs.Core.Interfaces;

namespace Quiplogs.Core.Dto.Requests.User
{
    public class UpdateUserRequest : IRequest<UpdateUserResponse>
    {
        public AppUser User { get; }
        public UpdateUserRequest(AppUser user)
        {
            User = user;
        }
    }
}
