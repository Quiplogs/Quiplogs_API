using System.Threading.Tasks;
using Api.Core.Interfaces.UseCases.Location;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Quiplogs.Core.Data.Entities;

namespace Api.UseCases.Location.Get
{
    public class LocationController : BaseApiController
    {
        private readonly IGetLocationUseCase _getLocationUseCase;
        private readonly GetLocationPresenter _getLocationPresenter;

        public LocationController(IGetLocationUseCase getLocationUseCase, GetLocationPresenter getLocationPresenter)
        {
            _getLocationUseCase = getLocationUseCase;
            _getLocationPresenter = getLocationPresenter;
        }


        [HttpGet("Get")]
        public async Task<ActionResult> Get([FromQuery] GetLocationRequest request)
        {
            if (!ModelState.IsValid)
            { // re-render the view when validation failed.
                return BadRequest(ModelState);
            }

            await _getLocationUseCase.Handle(new Core.Dto.Requests.Location.GetLocationRequest(request.Id), _getLocationPresenter);
            return _getLocationPresenter.ContentResult;
        }
    }
}