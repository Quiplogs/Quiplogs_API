using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Quiplogs.Core.Interfaces.UseCases.User;

namespace Api.UseCases.Auth.Login
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ILoginUseCase _loginWorkOrder;
        private readonly LoginPresenter _loginPresenter;

        public AuthController(ILoginUseCase loginWorkOrder, LoginPresenter loginPresenter)
        {
            _loginWorkOrder = loginWorkOrder;
            _loginPresenter = loginPresenter;
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login([FromBody] LoginRequest request)
        {
            if (!ModelState.IsValid)
            {
                // re-render the view when validation failed.
                return BadRequest(ModelState);
            }
            await _loginWorkOrder.Handle(new Quiplogs.Core.Dto.Requests.User.LoginRequest(request.Email, request.Password), _loginPresenter);
            return _loginPresenter.ContentResult;
        }
    }
}