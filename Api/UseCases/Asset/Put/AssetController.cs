using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Api.Services.Interfaces;
using Api.UseCases.Generic.Requests;
using Quiplogs.Assets.Data.Entities;

namespace Api.UseCases.Asset.Put
{
    public class AssetController : BaseApiController
    {
        private readonly IPutService<Quiplogs.Assets.Domain.Entities.Asset, AssetDto> _putService;

        public AssetController(IPutService<Quiplogs.Assets.Domain.Entities.Asset, AssetDto> putService)
        {
            _putService = putService;
        }

        [HttpPut()]
        public async Task<ActionResult> Put([FromBody] PutRequest<Quiplogs.Assets.Domain.Entities.Asset> request)
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