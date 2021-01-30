using System.Threading.Tasks;
using Api.Services.Interfaces;
using Api.UseCases.Generic.Requests;
using Microsoft.AspNetCore.Mvc;
using Quiplogs.Assets.Data.Entities;

namespace Api.UseCases.Asset.List
{
    public class AssetController : BaseApiController
    {
        private readonly IPagedListService<Quiplogs.Assets.Domain.Entities.Asset, AssetDto> _pagedService;

        public AssetController(IPagedListService<Quiplogs.Assets.Domain.Entities.Asset, AssetDto> pagedService)
        {
            _pagedService = pagedService;
        }

        [HttpPost("PagedList")]
        public async Task<ActionResult> PagedList([FromBody] PagedListRequest<Quiplogs.Assets.Domain.Entities.Asset> request)
        {
            if (!ModelState.IsValid)
            {
                // re-render the view when validation failed.
                return BadRequest(ModelState);
            }

            var result = await _pagedService.PagedList(request);
            return result;
        }
    }
}