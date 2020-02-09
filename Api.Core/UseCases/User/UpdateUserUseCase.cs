using Api.Core.Dto;
using Api.Core.Dto.Requests.User;
using Api.Core.Dto.Responses.User;
using Api.Core.Interfaces;
using Api.Core.Interfaces.Repositories.User;
using Api.Core.Interfaces.UseCases.User;
using System.Threading.Tasks;

namespace Api.Core.UseCases.User
{
    public class UpdateUserUseCase : IUpdateUserUseCase
    {
        private readonly IUserRepository _userRepository;

        public UpdateUserUseCase(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> Handle(UpdateUserRequest message, IOutputPort<UpdateUserResponse> outputPort)
        {
            var response = await _userRepository.Update(message.User);
            if (response.Success)
            {
                outputPort.Handle(new UpdateUserResponse(response.User, true));
                return true;
            }

            outputPort.Handle(new UpdateUserResponse(new[] { new Error(GlobalVariables.error_fetchUsersFailure, "Error removing user.") }));
            return false;
        }
    }
}
