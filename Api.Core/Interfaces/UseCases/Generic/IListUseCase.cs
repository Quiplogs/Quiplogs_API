using Quiplogs.Core.Domain.Entities;
using Quiplogs.Core.Dto.Requests.Generic;
using Quiplogs.Core.Dto.Responses.Generic;

namespace Quiplogs.Core.Interfaces.UseCases.Generic
{
    public interface IListUseCase<T1, T2> : IRequestHandler<ListRequest<T1>, ListResponse<T1>> where T1 : BaseEntity
    {
    }
}
