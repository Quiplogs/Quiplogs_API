using Quiplogs.Core.Domain.Entities;
using Quiplogs.Core.Dto.Responses.Generic;
using Quiplogs.Core.Interfaces;

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
