using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Quiplogs.Core.Interfaces.UseCases.User;

namespace Api.UseCases.Auth.Register
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IRegisterUseCase _registerWorkOrder;
        private readonly RegisterPresenter _registerUserPresenter;

        public AuthController(IRegisterUseCase registerWorkOrder, RegisterPresenter registerUserPresenter)
        {
            _registerWorkOrder = registerWorkOrder;
            _registerUserPresenter = registerUserPresenter;
        }

        [Route("Register")]
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] RegisterRequest request)
        {
            if (!ModelState.IsValid)
            { // re-render the view when validation failed.
                return BadRequest(ModelState);
            }
            await _registerWorkOrder.Handle(new Quiplogs.Core.Dto.Requests.User.RegisterRequest(request.FirstName, request.LastName, request.Email, request.UserName, request.Password, request.CompanyId), _registerUserPresenter);
            return _registerUserPresenter.ContentResult;
        }
    }
}