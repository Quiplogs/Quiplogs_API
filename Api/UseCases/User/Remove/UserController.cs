using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Quiplogs.Core.Interfaces.UseCases.User;

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

        [HttpDelete]
        public async Task<ActionResult> Remove([FromQuery] RemoveUserRequest request)
        {
            if (!ModelState.IsValid)
            { // re-render the view when validation failed.
                return BadRequest(ModelState);
            }
            await _removeUserUseCase.Handle(new Quiplogs.Core.Dto.Requests.User.RemoveUserRequest(request.Id), _removeUserPresenter);
            return _removeUserPresenter.ContentResult;
        }
    }
}