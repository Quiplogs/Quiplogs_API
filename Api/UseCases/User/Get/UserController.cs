using System.Threading.Tasks;
using Api.Core.Interfaces.UseCases.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.UseCases.User.Get
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [Authorize]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IGetUserUseCase _getUserUseCase;
        private readonly GetUserPresenter _getUserPresenter;

        public UserController(IGetUserUseCase getUserUseCase, GetUserPresenter getUserPresenter)
        {
            _getUserUseCase = getUserUseCase;
            _getUserPresenter = getUserPresenter;
        }


        [HttpPost("Get")]
        public async Task<ActionResult> Get([FromBody] GetUserRequest request)
        {
            if (!ModelState.IsValid)
            { // re-render the view when validation failed.
                return BadRequest(ModelState);
            }
            await _getUserUseCase.Handle(new Core.Dto.Requests.User.GetUserRequest(request.Id), _getUserPresenter);
            return _getUserPresenter.ContentResult;
        }
    }
}