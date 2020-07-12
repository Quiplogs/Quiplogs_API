using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Quiplogs.Assets.Interfaces.UseCases.AssetUsage;

namespace Api.UseCases.AssetUsage.Remove
{
    public class AssetUsageController : BaseApiController
    {
        private readonly IRemoveAssetUsageUseCase _useCase;
        private readonly RemoveAssetUsagePresenter _presenter;

        public AssetUsageController(IRemoveAssetUsageUseCase useCase, RemoveAssetUsagePresenter presenter)
        {
            _useCase = useCase;
            _presenter = presenter;
        }

        [HttpDelete()]
        public async Task<ActionResult> Remove([FromQuery] RemoveAssetUsageRequest request)
        {
            if (!ModelState.IsValid)
            { // re-render the view when validation failed.
                return BadRequest(ModelState);
            }

            await _useCase.Handle(new Quiplogs.Assets.Dto.Requests.AssetUsage.RemoveAssetUsageRequest(request.Id), _presenter);
            return _presenter.ContentResult;
        }
    }
}
