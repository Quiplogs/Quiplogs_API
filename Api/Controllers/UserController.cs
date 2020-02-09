using System.Threading.Tasks;
using Api.Core.Dto.Requests.User;
using Api.Core.Interfaces.UseCases.User;
using Api.Presenters.User;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IFetchUsersUseCase _fetchUsersUseCase;
        private readonly IGetUserUseCase _getUserUseCase;
        private readonly IRemoveUserUseCase _removeUserUseCase;
        private readonly IUpdateUserUseCase _updateUserUseCase;

        private readonly FetchUsersPresenter _fetchUsersPresenter;
        private readonly GetUserPresenter _getUserPresenter;
        private readonly UpdateUserPresenter _updateUserPresenter;
        private readonly RemoveUserPresenter _removeUserPresenter;

        public UserController(
                IFetchUsersUseCase fetchUsersUseCase,
                IGetUserUseCase getUserUseCase,
                IRemoveUserUseCase removeUserUseCase,
                IUpdateUserUseCase updateUserUseCase,
                FetchUsersPresenter fetchUsersPresenter,
                GetUserPresenter getUserPresenter,
                UpdateUserPresenter updateUserPresenter,
                RemoveUserPresenter removeUserPresenter)
        {
            _fetchUsersUseCase = fetchUsersUseCase;
            _getUserUseCase = getUserUseCase;
            _removeUserUseCase = removeUserUseCase;
            _updateUserUseCase = updateUserUseCase;

            _fetchUsersPresenter = fetchUsersPresenter;
            _getUserPresenter = getUserPresenter;
            _updateUserPresenter = updateUserPresenter;
            _removeUserPresenter = removeUserPresenter;
        }

        [HttpPost("FetchAll")]
        public async Task<ActionResult> FetchAll([FromBody] Models.Requests.User.FetchUsersRequest request)
        {
            if (!ModelState.IsValid)
            { // re-render the view when validation failed.
                return BadRequest(ModelState);
            }
            await _fetchUsersUseCase.Handle(new FetchUsersRequest(request.CompanyId, request.LocationId), _fetchUsersPresenter);
            return _fetchUsersPresenter.ContentResult;
        }

        [HttpPost("Get")]
        public async Task<ActionResult> Get([FromBody] Models.Requests.User.GetUserRequest request)
        {
            if (!ModelState.IsValid)
            { // re-render the view when validation failed.
                return BadRequest(ModelState);
            }
            await _getUserUseCase.Handle(new GetUserRequest(request.Id), _getUserPresenter);
            return _getUserPresenter.ContentResult;
        }

        [HttpPost("Update")]
        public async Task<ActionResult> Update([FromBody] Models.Requests.User.UpdateUserRequest request)
        {
            if (!ModelState.IsValid)
            { // re-render the view when validation failed.
                return BadRequest(ModelState);
            }
            await _updateUserUseCase.Handle(new UpdateUserRequest(request.User), _updateUserPresenter);
            return _updateUserPresenter.ContentResult;
        }

        [HttpPost("Remove")]
        public async Task<ActionResult> Remove([FromBody] Models.Requests.User.RemoveUserRequest request)
        {
            if (!ModelState.IsValid)
            { // re-render the view when validation failed.
                return BadRequest(ModelState);
            }
            await _removeUserUseCase.Handle(new RemoveUserRequest(request.Id), _removeUserPresenter);
            return _removeUserPresenter.ContentResult;
        }
    }
}