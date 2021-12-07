using Api.Presenters;
using Api.UseCases.Generic.Requests;
using Microsoft.AspNetCore.Mvc;
using Quiplogs.Assets.UseCases.Asset;
using System.Threading.Tasks;

namespace Api.UseCases.Asset.Put
{
    public class AssetController : BaseApiController
    {
        private readonly PutAssetUseCase _putUseCase;
        private readonly PutPresenter<Quiplogs.Assets.Domain.Entities.Asset> _putPresenter;

        public AssetController(PutAssetUseCase putUseCase, PutPresenter<Quiplogs.Assets.Domain.Entities.Asset> putPresenter)
        {
            _putUseCase = putUseCase;
            _putPresenter = putPresenter;
        }

        [HttpPut()]
        public async Task<ActionResult> Put([FromBody] PutRequest<Quiplogs.Assets.Domain.Entities.Asset> request)
        {
            if (!ModelState.IsValid)
            {
                // re-render the view when validation failed.
                return BadRequest(ModelState);
            }

            request.Model.CompanyId = GetCompanyId(request.Model.CompanyId);

            await _putUseCase.Handle(new Quiplogs.Core.Dto.Requests.Generic.PutRequest<Quiplogs.Assets.Domain.Entities.Asset>(request.Model), _putPresenter);
            return _putPresenter.ContentResult;
        }
    }
}