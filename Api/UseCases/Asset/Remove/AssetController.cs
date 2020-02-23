using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Quiplogs.Assets.Interfaces.UseCases.Asset;

namespace Api.UseCases.Asset.Remove
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [Authorize]
    [ApiController]
    public class AssetController : ControllerBase
    {
        private readonly IRemoveAssetUseCase _removeAssetUseCase;
        private readonly RemoveAssetPresenter _removeAssetPresenter;

        public AssetController(IRemoveAssetUseCase removeAssetUseCase, RemoveAssetPresenter removeAssetPresenter)
        {
            _removeAssetUseCase = removeAssetUseCase;
            _removeAssetPresenter = removeAssetPresenter;
        }

        [HttpPost("Remove")]
        public async Task<ActionResult> Remove([FromBody] RemoveAssetRequest request)
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