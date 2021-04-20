using System.Threading.Tasks;
using Quiplogs.Core.Dto;
using Quiplogs.Core.Dto.Requests.User;
using Quiplogs.Core.Dto.Responses.User;
using Quiplogs.Core.Interfaces;
using Quiplogs.Core.Interfaces.Repositories;
using Quiplogs.Core.Interfaces.UseCases.User;

namespace Quiplogs.Core.UseCases.User
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
            // Set Username to email address
            message.User.UserName = message.User.Email;

            //if(message.User.Password)

            var response = await _userRepository.Update(message.User);
            if (response.Success)
            {
                outputPort.Handle(new UpdateUserResponse(response.User, true));
                return true;
            }

            outputPort.Handle(new UpdateUserResponse(response.Errors));
            return false;
        }
    }
}
