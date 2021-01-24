using System;
using Api.Core.Interfaces;
using Quiplogs.Core.Dto.Responses.Generic;

namespace Quiplogs.Core.Dto.Requests.Generic
{
    public class RemoveRequest : IRequest<RemoveResponse>
    {
        public Guid Id { get; }

        public RemoveRequest(Guid id)
        {
            Id = id;
        }
    }
}
