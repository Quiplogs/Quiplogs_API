using Api.Services.Interfaces;
using Api.UseCases.Generic.Requests;
using Microsoft.AspNetCore.Mvc;
using Quiplogs.Assets.Data.Entities;
using System.Threading.Tasks;

namespace Api.UseCases.Asset.Remove
{
    public class AssetController : BaseApiController
    {
        private readonly IRemoveService<Quiplogs.Assets.Domain.Entities.Asset, AssetDto> _removeService;

        public AssetController(IRemoveService<Quiplogs.Assets.Domain.Entities.Asset, AssetDto> removeService)
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