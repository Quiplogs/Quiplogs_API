using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Quiplogs.Core.Interfaces.UseCases.User;

namespace Api.UseCases.User.Update
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [Authorize]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUpdateUserUseCase _updateUserUseCase;
        private readonly UpdateUserPresenter _updateUserPresenter;

        public UserController(IUpdateUserUseCase updateUserUseCase, UpdateUserPresenter updateUserPresenter)
        {
            _updateUserUseCase = updateUserUseCase;
            _updateUserPresenter = updateUserPresenter;
        }

        [HttpPost("Update")]
        public async Task<ActionResult> Update([FromBody] UpdateUserRequest request)
        {
            if (!ModelState.IsValid)
            { // re-render the view when validation failed.
                return BadRequest(ModelState);
            }
            await _updateUserUseCase.Handle(new Quiplogs.Core.Dto.Requests.User.UpdateUserRequest(request.User), _updateUserPresenter);
            return _updateUserPresenter.ContentResult;
        }
    }
}