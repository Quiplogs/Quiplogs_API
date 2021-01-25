using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Quiplogs.Core.Interfaces.UseCases.Location;

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

        [HttpDelete()]
        public async Task<ActionResult> Remove([FromQuery] RemoveLocationRequest request)
        {
            if (!ModelState.IsValid)
            { // re-render the view when validation failed.
                return BadRequest(ModelState);
            }
            await _removeLocationUseCase.Handle(new Quiplogs.Core.Dto.Requests.Location.RemoveLocationRequest(request.Id), _removeLocationPresenter);
            return _removeLocationPresenter.ContentResult;
        }
    }
}