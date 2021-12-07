using System.Threading.Tasks;
using Quiplogs.Core.Dto;
using Quiplogs.Core.Dto.Requests.User;
using Quiplogs.Core.Dto.Responses.User;
using Quiplogs.Core.Interfaces;
using Quiplogs.Core.Interfaces.Repositories;
using Quiplogs.Core.Interfaces.UseCases.User;

namespace Quiplogs.Core.UseCases.User
{
    public class FetchUsersUseCase : IFetchUsersUseCase
    {
        private readonly IUserRepository _userRepository;

        public FetchUsersUseCase(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> Handle(FetchUsersRequest request, IOutputPort<FetchUsersResponse> outputPort)
        {
            var response = await _userRepository.GetPagedList(request.CompanyId, request.PageNumber, request.PageSize, request.FilterParameters, request.LocationId);
            if (response.Success)
            {
                outputPort.Handle(new FetchUsersResponse(response.PagedResult, true));
                return true;
            }

            outputPort.Handle(new FetchUsersResponse(response.Errors));
            return false;
        }
    }
}
