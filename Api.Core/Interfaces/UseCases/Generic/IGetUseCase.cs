using Api.Core.Domain.Entities;
using Api.Core.Interfaces;
using Quiplogs.Core.Dto.Requests.Generic;
using Quiplogs.Core.Dto.Responses.Generic;

namespace Quiplogs.Core.Interfaces.UseCases.Generic
{
    public interface IGetUseCase<T1, T2> : IRequestHandler<GetRequest<T1>, GetResponse<T1>> where T1 : BaseEntity
    {
    }
}
