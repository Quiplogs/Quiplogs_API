using Api.Core.Domain;
using Api.Core.Domain.Entities;
using Api.Core.Dto.Requests.User;
using Api.Core.Dto.Responses.User;
using Api.Core.Interfaces;
using Api.Core.Interfaces.Repositories.User;
using Api.Core.Interfaces.UseCases.User;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Core.UseCases.User
{
    public class RegisterUseCase : IRegisterUseCase
    {
        private readonly IUserRepository _userRepository;

        public RegisterUseCase(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> Handle(RegisterRequest message, IOutputPort<RegisterResponse> outputPort)
        {
            var response = await _userRepository.Create(new AppUser(message.FirstName, message.LastName, message.Email, message.UserName, Role.Admin), message.Password);
            outputPort.Handle(response.Success ? new RegisterResponse(response.Id, true) : new RegisterResponse(response.Errors.Select(e => e.Description)));
            return response.Success;
        }
    }
}
