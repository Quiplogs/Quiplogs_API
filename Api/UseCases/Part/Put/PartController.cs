using Api.Services.Interfaces;
using Api.UseCases.Generic.Requests;
using Microsoft.AspNetCore.Mvc;
using Quiplogs.Inventory.Data.Entities;
using System.Threading.Tasks;

namespace Api.UseCases.Part.Put
{
    public class PartController : BaseApiController
    {
        private readonly IPutService<Quiplogs.Inventory.Domain.Entities.Part, PartDto> _putService;

        public PartController(IPutService<Quiplogs.Inventory.Domain.Entities.Part, PartDto> putService)
        {
            _putService = putService;
        }

        [HttpPut()]
        public async Task<ActionResult> Put([FromBody] PutRequest<Quiplogs.Inventory.Domain.Entities.Part> request)
        {
            if (!ModelState.IsValid)
            {
                // re-render the view when validation failed.
                return BadRequest(ModelState);
            }

            var result = await _putService.Put(request);
            return result;
        }
    }
}