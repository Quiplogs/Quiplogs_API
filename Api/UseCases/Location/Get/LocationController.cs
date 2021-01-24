 using System.Threading.Tasks;
 using Api.Services.Interfaces;
 using Api.UseCases.Generic.Get;
 using Microsoft.AspNetCore.Mvc;
 using Quiplogs.Core.Data.Entities;

 namespace Api.UseCases.Location.Get
{
    public class LocationController : BaseApiController
    {
        private readonly IGetService<Core.Domain.Entities.Location, LocationDto> _getService;

        public LocationController(IGetService<Core.Domain.Entities.Location, LocationDto> getService)
        {
            _getService = getService;
        }


        [HttpGet]
        public async Task<ActionResult> Get([FromQuery] GetRequest request)
        {
            if (!ModelState.IsValid)
            { 
                // re-render the view when validation failed.
                return BadRequest(ModelState);
            }

            var result = await _getService.Get(request);
            return result;
        }
    }
}