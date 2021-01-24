using Api.Core.Dto;
using Api.Core.Dto.Requests.User;
using Api.Core.Dto.Responses.User;
using Api.Core.Interfaces;
using Api.Core.Interfaces.Repositories;
using Api.Core.Interfaces.UseCases.User;
using System.Threading.Tasks;

namespace Api.Core.UseCases.User
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
