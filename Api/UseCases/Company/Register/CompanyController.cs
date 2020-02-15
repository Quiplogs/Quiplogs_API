using System.Threading.Tasks;
using Api.Core.Interfaces.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace Api.UseCases.Company.Register
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly IRegisterCompanyUseCase _registerCompanyService;
        private readonly RegisterCompanyPresenter _registerCompanyPresenter;

        public CompanyController(IRegisterCompanyUseCase registerCompanyService, RegisterCompanyPresenter registerCompanyPresenter)
        {
            _registerCompanyService = registerCompanyService;
            _registerCompanyPresenter = registerCompanyPresenter;
        }

        [HttpPost("Register")]
        public async Task<ActionResult> Company([FromBody] RegisterCompanyRequest request)
        {
            if (!ModelState.IsValid)
            { // re-render the view when validation failed.
                return BadRequest(ModelState);
            }

            var company = new Core.Dto.Requests.Company.RegisterCompanyRequest
            {
                Name = request.Name,
                TaxNumber = request.TaxNumber,
                SubscriptionId = request.SubscriptionId,
                Region = request.Region,
                PostCode = request.PostCode,
                Email = request.Email,
                Address1 = request.Address1,
                Address2 = request.Address2,
                City = request.City,
                Country = request.Country,
                LastName = request.LastName,
                LicenceNumber = request.LicenceNumber,
                PhoneNumber = request.PhoneNumber,
                UserName = request.UserName,
                UserPassword = request.Password
            };

            await _registerCompanyService.Handle(company, _registerCompanyPresenter);
            return _registerCompanyPresenter.ContentResult;
        }
    }
}