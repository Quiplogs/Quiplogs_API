using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Quiplogs.Assets.Interfaces.UseCases.Asset;

namespace Api.UseCases.Asset.Remove
{
    public class AssetController : BaseApiController
    {
        private readonly IRemoveAssetUseCase _removeAssetUseCase;
        private readonly RemoveAssetPresenter _removeAssetPresenter;

        public AssetController(IRemoveAssetUseCase removeAssetUseCase, RemoveAssetPresenter removeAssetPresenter)
        {
            _removeAssetUseCase = removeAssetUseCase;
            _removeAssetPresenter = removeAssetPresenter;
        }

        [HttpDelete()]
        public async Task<ActionResult> Remove([FromQuery] RemoveAssetRequest request)
        {
            if (!ModelState.IsValid)
            { // re-render the view when validation failed.
                return BadRequest(ModelState);
            }
            await _removeAssetUseCase.Handle(new Quiplogs.Assets.Dto.Requests.Asset.RemoveAssetRequest(request.Id), _removeAssetPresenter);
            return _removeAssetPresenter.ContentResult;
        }
    }
}