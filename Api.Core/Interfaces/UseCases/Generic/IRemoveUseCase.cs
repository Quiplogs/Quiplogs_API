using Quiplogs.Core.Dto.Requests.Generic;
using Quiplogs.Core.Dto.Responses.Generic;

namespace Quiplogs.Core.Interfaces.UseCases.Generic
{
    public interface IRemoveUseCase<T1, T2> : IRequestHandler<RemoveRequest, RemoveResponse>
    {
    }
}
