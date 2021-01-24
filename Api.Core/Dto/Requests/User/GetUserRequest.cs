using Api.Core.Dto.Responses.User;
using Api.Core.Interfaces;
using System;

namespace Api.Core.Dto.Requests.User
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
