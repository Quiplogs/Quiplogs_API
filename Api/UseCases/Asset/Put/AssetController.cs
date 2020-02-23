using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Quiplogs.Assets.Interfaces.UseCases.Asset;
using System.Threading.Tasks;

namespace Api.UseCases.Asset.Put
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [Authorize]
    [ApiController]
    public class AssetController : ControllerBase
    {
        private readonly IPutAssetUseCase _putAssetUseCase;
        private readonly PutAssetPresenter _putAssetPresenter;

        public AssetController(IPutAssetUseCase putAssetUseCase, PutAssetPresenter putAssetPresenter)
        {
            _putAssetUseCase = putAssetUseCase;
            _putAssetPresenter = putAssetPresenter;
        }

        [HttpPut("Put")]
        public async Task<ActionResult> Put([FromBody] PutAssetRequest request)
        {
            if (!ModelState.IsValid)
            { // re-render the view when validation failed.
                return BadRequest(ModelState);
            }
            await _putAssetUseCase.Handle(new Quiplogs.Assets.Dto.Requests.Asset.PutAssetRequest(request.Asset), _putAssetPresenter);
            return _putAssetPresenter.ContentResult;
        }
    }
}