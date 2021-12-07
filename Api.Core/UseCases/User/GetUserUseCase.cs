using System.Threading.Tasks;
using Quiplogs.Core.Dto;
using Quiplogs.Core.Dto.Requests.User;
using Quiplogs.Core.Dto.Responses.User;
using Quiplogs.Core.Interfaces;
using Quiplogs.Core.Interfaces.Repositories;
using Quiplogs.Core.Interfaces.UseCases.User;

namespace Quiplogs.Core.UseCases.User
{
    public class GetUserUseCase : IGetUserUseCase
    {
        private readonly IUserRepository _userRepository;

        public GetUserUseCase(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> Handle(GetUserRequest message, IOutputPort<GetUserResponse> outputPort)
        {
            var response = await _userRepository.Get(message.Id);
            if (response.Success)
            {
                outputPort.Handle(new GetUserResponse(response.User, true));
                return true;
            }

            outputPort.Handle(new GetUserResponse(new[] { new Error("", "No User Found.") }));
            return false;
        }
    }
}
