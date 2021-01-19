using Api.Core.Domain.Entities;
using Api.Core.Interfaces;
using Quiplogs.Core.Dto.Responses.Generic;

namespace Quiplogs.Core.Dto.Requests.Generic
{
    public class GetReuqest<T> : IRequest<GetResponse<T>> where T : BaseEntity
    {
        public string Id { get; }

        public GetReuqest(string id)
        {
            Id = id;
        }
    }
}
