using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Quiplogs.Assets.Interfaces.UseCases.Asset;

namespace Api.UseCases.Asset.Get
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [Authorize]
    [ApiController]
    public class AssetController : ControllerBase
    {
        private readonly IGetAssetUseCase _getAssetUseCase;
        private readonly GetAssetPresenter _getAssetPresenter;

        public AssetController(IGetAssetUseCase getAssetUseCase, GetAssetPresenter getAssetPresenter)
        {
            _getAssetUseCase = getAssetUseCase;
            _getAssetPresenter = getAssetPresenter;
        }


        [HttpGet("Get")]
        public async Task<ActionResult> Get([FromQuery] GetAssetRequest request)
        {
            if (!ModelState.IsValid)
            { // re-render the view when validation failed.
                return BadRequest(ModelState);
            }
            await _getAssetUseCase.Handle(new Quiplogs.Assets.Dto.Requests.Asset.GetAssetRequest(request.Id), _getAssetPresenter);
            return _getAssetPresenter.ContentResult;
        }
    }
}