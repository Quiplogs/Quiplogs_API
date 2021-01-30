
using Api.Services.Interfaces;
using Api.UseCases.Generic.Requests;
using Microsoft.AspNetCore.Mvc;
using Quiplogs.Assets.Data.Entities;
using System.Threading.Tasks;

namespace Api.UseCases.AssetUsage.Put
{
    public class AssetUsageController : BaseApiController
    {
        private readonly IPutService<Quiplogs.Assets.Domain.Entities.AssetUsage, AssetUsageDto> _putService;

        public AssetUsageController(IPutService<Quiplogs.Assets.Domain.Entities.AssetUsage, AssetUsageDto> putService)
        {
            _putService = putService;
        }

        [HttpPut()]
        public async Task<ActionResult> Put([FromBody] PutRequest<Quiplogs.Assets.Domain.Entities.AssetUsage> request)
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
