using Api.Core.Dto.Responses.User;
using Api.Core.Interfaces;
using System;

namespace Api.Core.Dto.Requests.User
{
    public class RemoveUserRequest : IRequest<RemoveUserResponse>
    {
        public Guid Id { get; }
        public RemoveUserRequest(Guid id)
        {
            Id = id;
        }
    }
}
