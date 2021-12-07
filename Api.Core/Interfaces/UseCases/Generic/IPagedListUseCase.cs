using Quiplogs.Core.Domain.Entities;
using Quiplogs.Core.Dto.Requests.Generic;
using Quiplogs.Core.Dto.Responses.Generic;

namespace Quiplogs.Core.Interfaces.UseCases.Generic
{
    public interface IPagedListUseCase<T1, T2> : IRequestHandler<PagedRequest<T1>, PagedResponse<T1>> where T1 : BaseEntity
    {
    }
}
