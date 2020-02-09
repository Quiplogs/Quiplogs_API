using Api.Core.Domain.Entities;
using Api.Core.Dto.Responses.User;
using Api.Core.Interfaces;

namespace Api.Core.Dto.Requests.User
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
