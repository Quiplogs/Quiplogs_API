using System.Threading.Tasks;
using Api.Services.Interfaces;
using Api.UseCases.Generic.Requests;
using Microsoft.AspNetCore.Mvc;
using Quiplogs.Assets.Data.Entities;

namespace Api.UseCases.Asset.Get
{
    public class AssetController : BaseApiController
    {
        private readonly IGetService<Quiplogs.Assets.Domain.Entities.Asset, AssetDto> _getService;

        public AssetController(IGetService<Quiplogs.Assets.Domain.Entities.Asset, AssetDto> getService)
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