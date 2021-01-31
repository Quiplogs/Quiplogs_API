using Api.Services.Interfaces;
using Api.UseCases.Generic.Requests;
using Microsoft.AspNetCore.Mvc;
using Quiplogs.Inventory.Data.Entities;
using System.Threading.Tasks;

namespace Api.UseCases.Part.Remove
{
    public class PartController : BaseApiController
    {
        private readonly IRemoveService<Quiplogs.Inventory.Domain.Entities.Part, PartDto> _removeService;

        public PartController(IRemoveService<Quiplogs.Inventory.Domain.Entities.Part, PartDto> removeService)
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