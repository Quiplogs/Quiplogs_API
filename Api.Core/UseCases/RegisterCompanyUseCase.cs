using System.Linq;
using System.Threading.Tasks;
using Quiplogs.Core.Domain;
using Quiplogs.Core.Domain.Entities;
using Quiplogs.Core.Dto.Requests.Company;
using Quiplogs.Core.Dto.Responses.Company;
using Quiplogs.Core.Interfaces;
using Quiplogs.Core.Interfaces.Repositories;
using Quiplogs.Core.Interfaces.UseCases;

namespace Quiplogs.Core.UseCases
{
    public class RegisterCompanyUseCase : IRegisterCompanyUseCase
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IUserRepository _userRepository;

        public RegisterCompanyUseCase(ICompanyRepository companyRepository, IUserRepository userRepository)
        {
            _companyRepository = companyRepository;
            _userRepository = userRepository;
        }

        public async Task<bool> Handle(RegisterCompanyRequest message, IOutputPort<RegisterCompanyResponse> outputPort)
        {
            var company = new Company
            {
                Name = message.Name,
                PhoneNumber = message.PhoneNumber,
                Address1 = message.Address1,
                Address2 = message.Address2,
                City = message.City,
                Country = message.Country,
                Email = message.Email,
                PostCode = message.PostCode,
                Region = message.Region,
                SubscriptionId = message.SubscriptionId,
                TaxNumber = message.TaxNumber
            };

            var response = await _companyRepository.Put(company);

            var user = new AppUser
            {
                FirstName = message.FirstName,
                LastName = message.LastName,
                Email = message.Email,
                UserName = message.UserName,
                Role = Role.SuperAdmin,
                CompanyId = response.Id,
                LocationId = null
            };

            //Create Initial User
            await _userRepository.Create(user, message.UserPassword);

            outputPort.Handle(response.Success ? new RegisterCompanyResponse(response.Id, true) : new RegisterCompanyResponse(response.Errors.Select(e => e.Description)));
            return response.Success;
        }
    }
}
