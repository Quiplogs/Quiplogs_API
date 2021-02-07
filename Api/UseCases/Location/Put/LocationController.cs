using System.Threading.Tasks;
using Api.Services.Interfaces;
using Api.UseCases.Generic.Requests;
using Microsoft.AspNetCore.Mvc;
using Quiplogs.Core.Data.Entities;

namespace Api.UseCases.Location.Put
{
    public class LocationController : BaseApiController
    {
        private readonly IPutService<Quiplogs.Core.Domain.Entities.Location, LocationDto> _putService;

        public LocationController(IPutService<Quiplogs.Core.Domain.Entities.Location, LocationDto> putService)
        {
            _putService = putService;
        }

        [HttpPut()]
        public async Task<ActionResult> Put([FromBody] PutRequest<Quiplogs.Core.Domain.Entities.Location> request)
        {
            if (!ModelState.IsValid)
            {
                // re-render the view when validation failed.
                return BadRequest(ModelState);
            }

            var result = await _putService.Put(request, GetCompanyId(request.Model.CompanyId));
            return result;
        }
    }
}