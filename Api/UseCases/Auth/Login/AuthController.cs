using Api.Core.Interfaces.UseCases.User;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Api.UseCases.Auth.Login
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ILoginUseCase _loginService;
        private readonly LoginPresenter _loginPresenter;

        public AuthController(ILoginUseCase loginService, LoginPresenter loginPresenter)
        {
            _loginService = loginService;
            _loginPresenter = loginPresenter;
        }

        // POST api/auth/login
        [HttpPost("login")]
        public async Task<ActionResult> Login([FromBody] LoginRequest request)
        {
            if (!ModelState.IsValid)
            { // re-render the view when validation failed.
                return BadRequest(ModelState);
            }
            await _loginService.Handle(new Core.Dto.Requests.User.LoginRequest(request.Email, request.Password), _loginPresenter);
            return _loginPresenter.ContentResult;
        }
    }
}