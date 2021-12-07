using System;
using Quiplogs.Core.Dto.Responses.User;
using Quiplogs.Core.Interfaces;

namespace Quiplogs.Core.Dto.Requests.User
{
    public class GetUserRequest : IRequest<GetUserResponse>
    {
        public Guid Id { get; }
        public GetUserRequest(Guid id)
        {
            Id = id;
        }
    }
}
