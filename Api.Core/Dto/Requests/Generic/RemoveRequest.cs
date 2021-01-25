using System;
using Quiplogs.Core.Dto.Responses.Generic;
using Quiplogs.Core.Interfaces;

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
