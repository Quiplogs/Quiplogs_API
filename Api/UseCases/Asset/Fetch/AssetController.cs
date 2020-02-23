using Microsoft.AspNetCore.Mvc;
using Quiplogs.Assets.Interfaces.UseCases.Asset;
using System.Threading.Tasks;

namespace Api.UseCases.Asset.Fetch
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    //[Authorize]
    [ApiController]
    public class AssetController : ControllerBase
    {
        private readonly IFetchAssetUseCase _fetchAssetUseCase;
        private readonly FetchAssetPresenter _fetchAssetPresenter;

        public AssetController(IFetchAssetUseCase fetchAssetUseCase, FetchAssetPresenter fetchAssetPresenter)
        {
            _fetchAssetUseCase = fetchAssetUseCase;
            _fetchAssetPresenter = fetchAssetPresenter;
        }

        [HttpGet("List")]
        public async Task<ActionResult> List([FromQuery] FetchAssetRequest request)
        {
            if (!ModelState.IsValid)
            { // re-render the view when validation failed.
                return BadRequest(ModelState);
            }
            await _fetchAssetUseCase.Handle(new Quiplogs.Assets.Dto.Requests.Asset.FetchAssetRequest(request.CompanyId, request.LocationId, request.PageNumber), _fetchAssetPresenter);
            return _fetchAssetPresenter.ContentResult;
        }
    }
}