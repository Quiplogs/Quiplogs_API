using Api.UseCases.Generic.Requests;
using Microsoft.AspNetCore.Mvc;
using Quiplogs.Assets.UseCases.Asset;
using System.Threading.Tasks;
using Api.Presenters;

namespace Api.UseCases.Asset.Remove
{
    public class AssetController : BaseApiController
    {
        private readonly RemoveAssetUseCase _useCase;
        private readonly RemovePresenter _presenter;

        public AssetController(RemoveAssetUseCase useCase, RemovePresenter presenter)
        {
            _useCase = useCase;
            _presenter = presenter;
        }

        [HttpDelete]
        public async Task<ActionResult> Put([FromQuery] RemoveRequest request)
        {
            if (!ModelState.IsValid)
            {
                // re-render the view when validation failed.
                return BadRequest(ModelState);
            }

            await _useCase.Handle(new Quiplogs.Core.Dto.Requests.Generic.RemoveRequest(request.Id), _presenter);
            return _presenter.ContentResult;
        }
    }
}