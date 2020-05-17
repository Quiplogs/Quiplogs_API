using Api.Core.Domain;
using Api.Core.Domain.Entities;
using Api.Core.Dto.Requests.User;
using Api.Core.Dto.Responses.User;
using Api.Core.Interfaces;
using Api.Core.Interfaces.Repositories;
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
            var user = new AppUser
            {
                FirstName = message.FirstName,
                LastName = message.LastName,
                Email = message.Email,
                UserName = message.UserName,
                Role = Role.SuperAdmin,
                CompanyId = message.CompanyId,
                LocationId = null
            };

            var response = await _userRepository.Create(user, message.Password);
            outputPort.Handle(response.Success ? new RegisterResponse(response.Id, true) : new RegisterResponse(response.Errors.Select(e => e.Description)));
            return response.Success;
        }
    }
}
