using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Quiplogs.Assets.Interfaces.UseCases.AssetUsage;

namespace Api.UseCases.AssetUsage.Get
{
    public class AssetUsageController : BaseApiController
    {
        private readonly IGetAssetUsageUseCase _getAssetUsageUseCase;
        private readonly GetAssetUsagePresenter _getAssetUsagePresenter;

        public AssetUsageController(IGetAssetUsageUseCase getAssetUseCase, GetAssetUsagePresenter getAssetPresenter)
        {
            _getAssetUsageUseCase = getAssetUseCase;
            _getAssetUsagePresenter = getAssetPresenter;
        }


        [HttpGet()]
        public async Task<ActionResult> Get([FromQuery] GetAssetUsageRequest request)
        {
            if (!ModelState.IsValid)
            { // re-render the view when validation failed.
                return BadRequest(ModelState);
            }

            await _getAssetUsageUseCase.Handle(new Quiplogs.Assets.Dto.Requests.AssetUsage.GetAssetUsageRequest(request.Id), _getAssetUsagePresenter);
            return _getAssetUsagePresenter.ContentResult;
        }
    }
}
