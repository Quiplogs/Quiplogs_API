using Api.Core.Domain.Entities;
using Api.Core.Interfaces;
using Quiplogs.Core.Dto.Requests.Generic;
using Quiplogs.Core.Dto.Responses.Generic;

namespace Quiplogs.Core.Interfaces.UseCases.Generic
{
    public interface IGetUseCase<T> : IRequestHandler<GetRequest<T>, GetResponse<T>> where T : BaseEntity
    {
    }
}
