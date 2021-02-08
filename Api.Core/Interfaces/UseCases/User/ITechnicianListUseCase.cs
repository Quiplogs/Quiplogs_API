using Quiplogs.Core.Domain.Entities;
using Quiplogs.Core.Dto.Requests.Generic;
using Quiplogs.Core.Dto.Responses.Generic;

namespace Quiplogs.Core.Interfaces.UseCases.User
{
    public interface ITechnicianListUseCase<T> : IRequestHandler<ListRequest<T>, ListResponse<T>> where T : BaseEntity
    {
    }
}
