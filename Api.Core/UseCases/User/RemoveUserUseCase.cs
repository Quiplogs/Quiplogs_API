using Api.Core.Dto;
using Api.Core.Dto.Requests.User;
using Api.Core.Dto.Responses.User;
using Api.Core.Interfaces;
using Api.Core.Interfaces.Repositories.User;
using Api.Core.Interfaces.UseCases.User;
using System.Threading.Tasks;

namespace Api.Core.UseCases.User
{
    public class RemoveUserUseCase : IRemoveUserUseCase
    {
        private readonly IUserRepository _userRepository;

        public RemoveUserUseCase(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> Handle(RemoveUserRequest message, IOutputPort<RemoveUserResponse> outputPort)
        {
            var response = await _userRepository.Remove(message.Id);
            if (response.Success)
            {
                outputPort.Handle(new RemoveUserResponse(response.UserName, true));
                return true;
            }

            outputPort.Handle(new RemoveUserResponse(new[] { new Error(GlobalVariables.error_fetchUsersFailure, "Error removing user.") }));
            return false;
        }
    }
}
