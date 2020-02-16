using System.Threading.Tasks;
using Api.Core.Interfaces.UseCases.Location;
using Microsoft.AspNetCore.Mvc;

namespace Api.UseCases.Location.Remove
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    //[Authorize]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly IRemoveLocationUseCase _removeLocationUseCase;
        private readonly RemoveLocationPresenter _removeLocationPresenter;

        public LocationController(IRemoveLocationUseCase removeLocationUseCase, RemoveLocationPresenter removeLocationPresenter)
        {
            _removeLocationUseCase = removeLocationUseCase;
            _removeLocationPresenter = removeLocationPresenter;
        }

        [HttpPost("Remove")]
        public async Task<ActionResult> Remove([FromBody] RemoveLocationRequest request)
        {
            if (!ModelState.IsValid)
            { // re-render the view when validation failed.
                return BadRequest(ModelState);
            }
            await _removeLocationUseCase.Handle(new Core.Dto.Requests.Location.RemoveLocationRequest(request.Id), _removeLocationPresenter);
            return _removeLocationPresenter.ContentResult;
        }
    }
}