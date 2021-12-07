using System;
using Quiplogs.Core.Dto.Responses.User;
using Quiplogs.Core.Interfaces;

namespace Quiplogs.Core.Dto.Requests.User
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
