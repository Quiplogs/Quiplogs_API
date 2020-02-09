using Api.Core.Dto.Requests.User;
using Api.Core.Dto.Responses.User;

namespace Api.Core.Interfaces.UseCases.User
{
    public interface IFetchUsersUseCase : IRequestHandler<FetchUsersRequest, FetchUsersResponse>
    {
    }
}
