using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Quiplogs.Assets.Interfaces.UseCases.Asset;

namespace Api.UseCases.Asset.Get
{
    public class AssetController : BaseApiController
    {
        private readonly IGetAssetUseCase _getAssetUseCase;
        private readonly GetAssetPresenter _getAssetPresenter;

        public AssetController(IGetAssetUseCase getAssetUseCase, GetAssetPresenter getAssetPresenter)
        {
            _getAssetUseCase = getAssetUseCase;
            _getAssetPresenter = getAssetPresenter;
        }


        [HttpGet()]
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