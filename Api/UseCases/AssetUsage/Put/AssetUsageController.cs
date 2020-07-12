
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Quiplogs.Assets.Interfaces.UseCases.AssetUsage;

namespace Api.UseCases.AssetUsage.Put
{
    public class AssetUsageControlle : BaseApiController
    {
        private readonly IPutAssetUsageUseCase _useCase;
        private readonly PutAssetUsagePresenter _presenter;

        public AssetUsageControlle(IPutAssetUsageUseCase useCase, PutAssetUsagePresenter presenter)
        {
            _useCase = useCase;
            _presenter = presenter;
        }

        [HttpPut()]
        public async Task<ActionResult> Put([FromBody] PutAssetUsageRequest request)
        {
            if (!ModelState.IsValid)
            { // re-render the view when validation failed.
                return BadRequest(ModelState);
            }

            await _useCase.Handle(new Quiplogs.Assets.Dto.Requests.AssetUsage.PutAssetUsageRequest(request.WorkDone, request.DateCaptured, request.AssetId), _presenter);
            return _presenter.ContentResult;
        }
    }
}
