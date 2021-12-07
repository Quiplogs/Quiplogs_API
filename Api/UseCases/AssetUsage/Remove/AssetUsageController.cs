using Api.Services.Interfaces;
using Api.UseCases.Generic.Requests;
using Microsoft.AspNetCore.Mvc;
using Quiplogs.Assets.Data.Entities;
using System.Threading.Tasks;

namespace Api.UseCases.AssetUsage.Remove
{
    public class AssetUsageController : BaseApiController
    {
        private readonly IRemoveService<Quiplogs.Assets.Domain.Entities.AssetUsage, AssetUsageDto> _removeService;

        public AssetUsageController(IRemoveService<Quiplogs.Assets.Domain.Entities.AssetUsage, AssetUsageDto> removeService)
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
