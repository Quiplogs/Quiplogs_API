using Api.Core.Dto.Responses.User;
using Api.Core.Interfaces;

namespace Api.Core.Dto.Requests.User
{
    public class GetUserRequest : IRequest<GetUserResponse>
    {
        public string Id { get; }
        public GetUserRequest(string id)
        {
            Id = id;
        }
    }
}
