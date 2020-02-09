using System.Threading.Tasks;
using Api.Core.Dto.Requests.Company;
using Api.Core.Dto.Requests.User;
using Api.Core.Interfaces.UseCases;
using Api.Core.Interfaces.UseCases.User;
using Api.Presenters;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly IRegisterUseCase _registerService;
        private readonly RegisterPresenter _registerUserPresenter;
        private readonly IRegisterCompanyUseCase _registerCompanyService;
        private readonly RegisterCompanyPresenter _registerCompanyPresenter;

        public RegisterController(IRegisterUseCase registerService, RegisterPresenter registerUserPresenter, IRegisterCompanyUseCase registerCompanyService, RegisterCompanyPresenter registerCompanyPresenter)
        {
            _registerService = registerService;
            _registerUserPresenter = registerUserPresenter;
            _registerCompanyService = registerCompanyService;
            _registerCompanyPresenter = registerCompanyPresenter;
        }

        [Route("User")]
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Models.Requests.RegisterRequest request)
        {
            if (!ModelState.IsValid)
            { // re-render the view when validation failed.
                return BadRequest(ModelState);
            }
            await _registerService.Handle(new RegisterRequest(request.FirstName, request.LastName, request.Email, request.UserName, request.Password), _registerUserPresenter);
            return _registerUserPresenter.ContentResult;
        }

        [Route("Company")]
        [HttpPost]
        public async Task<ActionResult> Company([FromBody] Models.Requests.RegisterCompanyRequest request)
        {
            if (!ModelState.IsValid)
            { // re-render the view when validation failed.
                return BadRequest(ModelState);
            }

            var company = new RegisterCompanyRequest
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
                PhoneNumber= request.PhoneNumber,
                UserName = request.UserName,
                UserPassword = request.Password
            };

            await _registerCompanyService.Handle(company, _registerCompanyPresenter);
            return _registerCompanyPresenter.ContentResult;
        }
    }
}
