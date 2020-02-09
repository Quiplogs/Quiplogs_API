using System.Threading.Tasks;
using Api.Core.Dto.Requests.User;
using Api.Core.Interfaces.UseCases.User;
using Api.Presenters;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
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
        public async Task<ActionResult> Login([FromBody] Models.Requests.LoginRequest request)
        {
            if (!ModelState.IsValid)
            { // re-render the view when validation failed.
                return BadRequest(ModelState);
            }
            await _loginService.Handle(new LoginRequest(request.Email, request.Password), _loginPresenter);
            return _loginPresenter.ContentResult;
        }
    }
}