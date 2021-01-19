using Api.Core.Domain.Entities;
using Api.Core.Interfaces;
using Quiplogs.Core.Dto.Responses.Generic;

namespace Quiplogs.Core.Dto.Requests.Generic
{
    public class PutRequest<T> : IRequest<PutResponse<T>> where T : BaseEntity
    {
        public T Model { get; }

        public PutRequest(T model)
        {
            Model = model;
        }
    }
}
