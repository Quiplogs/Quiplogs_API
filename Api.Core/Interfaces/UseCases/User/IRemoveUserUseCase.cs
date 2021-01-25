using Quiplogs.Core.Dto.Requests.User;
using Quiplogs.Core.Dto.Responses.User;

namespace Quiplogs.Core.Interfaces.UseCases.User
{
    public interface IRemoveUserUseCase : IRequestHandler<RemoveUserRequest, RemoveUserResponse>
    {
    }
}
