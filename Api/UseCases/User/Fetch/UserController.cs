using System.Threading.Tasks;
using Api.Core.Interfaces.UseCases.User;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet("List")]
        public async Task<ActionResult> List([FromQuery] FetchUsersRequest request)
        {
            if (!ModelState.IsValid)
            { // re-render the view when validation failed.
                return BadRequest(ModelState);
            }

            var companyId = request.CompanyId;
            if (string.IsNullOrEmpty(companyId))
            {
                companyId = this.GetCompanyId();
            }

            await _fetchUsersUseCase.Handle(new Core.Dto.Requests.User.FetchUsersRequest(companyId, request.LocationId), _fetchUsersPresenter);
            return _fetchUsersPresenter.ContentResult;
        }        
    }
}