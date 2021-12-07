using Quiplogs.Core.Domain.Entities;
using Quiplogs.Core.Dto;
using Quiplogs.Core.Dto.Requests.Generic;
using Quiplogs.Core.Dto.Responses.Generic;
using Quiplogs.Core.Interfaces;
using Quiplogs.Core.Interfaces.Repositories;
using Quiplogs.Core.Interfaces.UseCases.User;
using System.Threading.Tasks;

namespace Quiplogs.Core.UseCases.User
{
    public class TechnicianListUseCase : ITechnicianListUseCase<AppUser>
    {
        private readonly IUserRepository _userRepository;

        public TechnicianListUseCase(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> Handle(ListRequest<AppUser> request, IOutputPort<ListResponse<AppUser>> outputPort)
        {
            var response = await _userRepository.GetAllTechnicians(request.CompanyId, request.LocationId);
            if (response.Success)
            {
                outputPort.Handle(new ListResponse<AppUser>(response.Users, true));
                return true;
            }

            outputPort.Handle(new ListResponse<AppUser>(new[] { new Error("", "No Technicians Found.") }));
            return false;
        }
    }
}
