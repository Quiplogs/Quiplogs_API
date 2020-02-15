using Api.Core.Interfaces.UseCases.User;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Api.UseCases.Auth.Register
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IRegisterUseCase _registerService;
        private readonly RegisterPresenter _registerUserPresenter;

        public AuthController(IRegisterUseCase registerService, RegisterPresenter registerUserPresenter)
        {
            _registerService = registerService;
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
            await _registerService.Handle(new Core.Dto.Requests.User.RegisterRequest(request.FirstName, request.LastName, request.Email, request.UserName, request.Password), _registerUserPresenter);
            return _registerUserPresenter.ContentResult;
        }
    }
}