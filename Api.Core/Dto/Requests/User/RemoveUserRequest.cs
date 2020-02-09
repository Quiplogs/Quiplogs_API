using Api.Core.Dto.Responses.User;
using Api.Core.Interfaces;

namespace Api.Core.Dto.Requests.User
{
    public class RemoveUserRequest : IRequest<RemoveUserResponse>
    {
        public string Id { get; }
        public RemoveUserRequest(string id)
        {
            Id = id;
        }
    }
}
