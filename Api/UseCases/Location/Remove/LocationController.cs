using Api.Services.Interfaces;
using Api.UseCases.Generic.Requests;
using Microsoft.AspNetCore.Mvc;
using Quiplogs.Core.Data.Entities;
using System.Threading.Tasks;

namespace Api.UseCases.Location.Remove
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    //[Authorize]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly IRemoveService<Quiplogs.Core.Domain.Entities.Location, LocationDto> _removeService;

        public LocationController(IRemoveService<Quiplogs.Core.Domain.Entities.Location, LocationDto> removeService)
        {
            _removeService = removeService;
        }

        [HttpDelete()]
        public async Task<ActionResult> Delete([FromBody] RemoveRequest request)
        {
            if (!ModelState.IsValid)
            {
                // re-render the view when validation failed.
                return BadRequest(ModelState);
            }

            var result = await _removeService.Put(request);
            return result;
        }
    }
}