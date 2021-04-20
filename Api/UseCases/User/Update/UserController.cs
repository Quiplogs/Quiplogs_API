using Microsoft.AspNetCore.Mvc;
using Quiplogs.Core.Interfaces.UseCases.User;
using System.Threading.Tasks;

namespace Api.UseCases.User.Update
{
    public class UserController : BaseApiController
    {
        private readonly IUpdateUserUseCase _updateUserUseCase;
        private readonly UpdateUserPresenter _updateUserPresenter;

        public UserController(IUpdateUserUseCase updateUserUseCase, UpdateUserPresenter updateUserPresenter)
        {
            _updateUserUseCase = updateUserUseCase;
            _updateUserPresenter = updateUserPresenter;
        }

        [HttpPut]
        public async Task<ActionResult> Update([FromBody] UpdateUserRequest request)
        {
            if (!ModelState.IsValid)
            { 
                // re-render the view when validation failed.
                return BadRequest(ModelState);
            }

            request.Model.CompanyId = GetCompanyId(request.Model.CompanyId);

            await _updateUserUseCase.Handle(new Quiplogs.Core.Dto.Requests.User.UpdateUserRequest(request.Model), _updateUserPresenter);
            return _updateUserPresenter.ContentResult;
        }
    }
}