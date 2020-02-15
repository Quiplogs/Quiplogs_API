using System.Threading.Tasks;
using Api.Core.Interfaces.UseCases.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.UseCases.User.Remove
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [Authorize]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IRemoveUserUseCase _removeUserUseCase;
        private readonly RemoveUserPresenter _removeUserPresenter;

        public UserController(IRemoveUserUseCase removeUserUseCase, RemoveUserPresenter removeUserPresenter)
        {
            _removeUserUseCase = removeUserUseCase;
            _removeUserPresenter = removeUserPresenter;
        }

        [HttpPost("Remove")]
        public async Task<ActionResult> Remove([FromBody] RemoveUserRequest request)
        {
            if (!ModelState.IsValid)
            { // re-render the view when validation failed.
                return BadRequest(ModelState);
            }
            await _removeUserUseCase.Handle(new Core.Dto.Requests.User.RemoveUserRequest(request.Id), _removeUserPresenter);
            return _removeUserPresenter.ContentResult;
        }
    }
}