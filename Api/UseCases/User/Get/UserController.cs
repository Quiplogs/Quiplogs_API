using Microsoft.AspNetCore.Mvc;
using Quiplogs.Core.Interfaces.UseCases.User;
using System.Threading.Tasks;

namespace Api.UseCases.User.Get
{
    public class UserController : BaseApiController
    {
        private readonly IGetUserUseCase _getUserUseCase;
        private readonly GetUserPresenter _getUserPresenter;

        public UserController(IGetUserUseCase getUserUseCase, GetUserPresenter getUserPresenter)
        {
            _getUserUseCase = getUserUseCase;
            _getUserPresenter = getUserPresenter;
        }


        [HttpGet]
        public async Task<ActionResult> Get([FromQuery] GetUserRequest request)
        {
            if (!ModelState.IsValid)
            {
                // re-render the view when validation failed.
                return BadRequest(ModelState);
            }
            await _getUserUseCase.Handle(new Quiplogs.Core.Dto.Requests.User.GetUserRequest(request.Id), _getUserPresenter);
            return _getUserPresenter.ContentResult;
        }
    }
}