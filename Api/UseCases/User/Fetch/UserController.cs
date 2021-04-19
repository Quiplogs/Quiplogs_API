using System.Threading.Tasks;
using Api.UseCases.Generic.Requests;
using Microsoft.AspNetCore.Mvc;
using Quiplogs.Core.Interfaces.UseCases.User;

namespace Api.UseCases.User.Fetch
{
    public class UserController : BaseApiController
    {
        private readonly IFetchUsersUseCase _fetchUsersUseCase;
        private readonly FetchUsersPresenter _fetchUsersPresenter;

        public UserController(IFetchUsersUseCase fetchUsersUseCase, FetchUsersPresenter fetchUsersPresenter)
        {
            _fetchUsersUseCase = fetchUsersUseCase;
            _fetchUsersPresenter = fetchUsersPresenter;
        }

        [HttpPost("PagedList")]
        public async Task<ActionResult> List([FromBody] PagedListRequest request)
        {
            if (!ModelState.IsValid)
            { 
                // re-render the view when validation failed.
                return BadRequest(ModelState);
            }

            await _fetchUsersUseCase.Handle(new Quiplogs.Core.Dto.Requests.User.FetchUsersRequest(GetCompanyId(request.CompanyId), request.LocationId, request.PageSize, request.PageNumber), _fetchUsersPresenter);
            return _fetchUsersPresenter.ContentResult;
        }
    }
}