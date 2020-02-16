using System.Threading.Tasks;
using Api.Core.Interfaces.UseCases.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.UseCases.User.Fetch
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [Authorize]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IFetchUsersUseCase _fetchUsersUseCase;
        private readonly FetchUsersPresenter _fetchUsersPresenter;  

        public UserController(IFetchUsersUseCase fetchUsersUseCase, FetchUsersPresenter fetchUsersPresenter)
        {
            _fetchUsersUseCase = fetchUsersUseCase;
            _fetchUsersPresenter = fetchUsersPresenter;
        }

        [HttpGet("List")]
        public async Task<ActionResult> List([FromQuery] FetchUsersRequest request)
        {
            if (!ModelState.IsValid)
            { // re-render the view when validation failed.
                return BadRequest(ModelState);
            }
            await _fetchUsersUseCase.Handle(new Core.Dto.Requests.User.FetchUsersRequest(request.CompanyId, request.LocationId), _fetchUsersPresenter);
            return _fetchUsersPresenter.ContentResult;
        }        
    }
}