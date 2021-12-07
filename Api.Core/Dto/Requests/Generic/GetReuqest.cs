using System;
using Quiplogs.Core.Domain.Entities;
using Quiplogs.Core.Dto.Responses.Generic;
using Quiplogs.Core.Interfaces;

namespace Quiplogs.Core.Dto.Requests.Generic
{
    public class GetRequest<T> : IRequest<GetResponse<T>> where T : BaseEntity
    {
        public Guid Id { get; }

        public GetRequest(Guid id)
        {
            Id = id;
        }
    }
}
