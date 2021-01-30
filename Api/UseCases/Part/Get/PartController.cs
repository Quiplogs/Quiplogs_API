using Api.Services.Interfaces;
using Api.UseCases.Generic.Requests;
using Microsoft.AspNetCore.Mvc;
using Quiplogs.Inventory.Data.Entities;
using System.Threading.Tasks;

namespace Api.UseCases.Part.Get
{
    public class PartController : BaseApiController
    {
        private readonly IGetService<Quiplogs.Inventory.Domain.Entities.Part, PartDto> _getService;

        public PartController(IGetService<Quiplogs.Inventory.Domain.Entities.Part, PartDto> getService)
        {
            _getService = getService;
        }

        [HttpGet()]
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