using System.Threading.Tasks;
using Quiplogs.Core.Dto;
using Quiplogs.Core.Dto.Requests.User;
using Quiplogs.Core.Dto.Responses.User;
using Quiplogs.Core.Interfaces;
using Quiplogs.Core.Interfaces.Repositories;
using Quiplogs.Core.Interfaces.UseCases.User;

namespace Quiplogs.Core.UseCases.User
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

            outputPort.Handle(new RemoveUserResponse(new[] { new Error("", "Error removing user.") }));
            return false;
        }
    }
}
