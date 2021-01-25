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

        public async Task<bool> Handle(FetchUsersRequest message, IOutputPort<FetchUsersResponse> outputPort)
        {
            var response = await _userRepository.GetAll(message.CompanyId, message.LocationId);
            if (response.Success)
            {
                outputPort.Handle(new FetchUsersResponse(response.Users, true));
                return true;
            }

            outputPort.Handle(new FetchUsersResponse(new[] { new Error("", "No Users Found.") }));
            return false;
        }
    }
}
