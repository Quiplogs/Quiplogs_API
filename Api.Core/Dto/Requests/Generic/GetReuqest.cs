using System;
using Api.Core.Domain.Entities;
using Api.Core.Interfaces;
using Quiplogs.Core.Dto.Responses.Generic;

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
