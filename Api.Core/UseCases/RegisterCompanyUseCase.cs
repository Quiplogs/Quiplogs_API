using Api.Core.Domain;
using Api.Core.Domain.Entities;
using Api.Core.Dto.Requests.Company;
using Api.Core.Dto.Responses.Company;
using Api.Core.Interfaces;
using Api.Core.Interfaces.Repositories;
using Api.Core.Interfaces.UseCases;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Core.UseCases
{
    public class RegisterCompanyUseCase : IRegisterCompanyUseCase
    {
        private readonly ICompanyRepository _companyRepository;

        public RegisterCompanyUseCase(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public async Task<bool> Handle(RegisterCompanyRequest message, IOutputPort<RegisterCompanyResponse> outputPort)
        {
            var users = new List<AppUser>();
            users.Add(new AppUser(message.UserName, message.LastName, message.Email, message.UserName, Role.Admin));

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
                TaxNumber = message.TaxNumber,
                Users = users
            };

            var response = await _companyRepository.Create(company, message.UserPassword);
            outputPort.Handle(response.Success ? new RegisterCompanyResponse(response.Id, true) : new RegisterCompanyResponse(response.Errors.Select(e => e.Description)));
            return response.Success;
        }
    }
}
