using System.Threading.Tasks;
using Api.Services.Interfaces;
using Api.UseCases.Generic.Requests;
using Microsoft.AspNetCore.Mvc;
using Quiplogs.Assets.Data.Entities;

namespace Api.UseCases.AssetUsage.Get
{
    public class AssetUsageController : BaseApiController
    {
        private readonly IGetService<Quiplogs.Assets.Domain.Entities.AssetUsage, AssetUsageDto> _getService;

        public AssetUsageController(IGetService<Quiplogs.Assets.Domain.Entities.AssetUsage, AssetUsageDto> getService)
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
