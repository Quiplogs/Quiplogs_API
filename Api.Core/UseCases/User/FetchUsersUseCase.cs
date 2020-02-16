using Api.Core.Dto;
using Api.Core.Dto.Requests.User;
using Api.Core.Dto.Responses.User;
using Api.Core.Interfaces;
using Api.Core.Interfaces.Repositories;
using Api.Core.Interfaces.UseCases.User;
using System.Threading.Tasks;

namespace Api.Core.UseCases.User
{
    public class FetchUsersUseCase : IFetchUsersUseCase
    {
        private readonly IUserRepository _userRepository;

        public FetchUsersUseCase(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> Handle(FetchUsersRequest message, IOutputPort<FetchUsersResponse> outputPort)
        {
            var response = await _userRepository.GetAll(message.CompanyId, message.LocationId);
            if (response.Success)
            {
                outputPort.Handle(new FetchUsersResponse(response.Users, true));
                return true;
            }

            outputPort.Handle(new FetchUsersResponse(new[] { new Error(GlobalVariables.error_fetchUsersFailure, "No Users Found.") }));
            return false;
        }
    }
}
