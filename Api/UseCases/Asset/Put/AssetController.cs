using Microsoft.AspNetCore.Mvc;
using Quiplogs.Assets.Interfaces.UseCases.Asset;
using System.Threading.Tasks;

namespace Api.UseCases.Asset.Put
{
    public class AssetController : BaseApiController
    {
        private readonly IPutAssetUseCase _putAssetUseCase;
        private readonly PutAssetPresenter _putAssetPresenter;

        public AssetController(IPutAssetUseCase putAssetUseCase, PutAssetPresenter putAssetPresenter)
        {
            _putAssetUseCase = putAssetUseCase;
            _putAssetPresenter = putAssetPresenter;
        }

        [HttpPut()]
        public async Task<ActionResult> Put([FromBody] PutAssetRequest request)
        {
            if (!ModelState.IsValid)
            { // re-render the view when validation failed.
                return BadRequest(ModelState);
            }

            var companyId = request.CompanyId;
            if (string.IsNullOrEmpty(companyId))
            {
                companyId = this.GetCompanyId();
            }
             
            await _putAssetUseCase.Handle(new Quiplogs.Assets.Dto.Requests.Asset.PutAssetRequest(request.Name, request.Make, request.Model, request.SerialNumber, request.ManufacturedDate, request.PurchasedDate, request. CurrentWorkDone, request.UoM, request.ImgFileName, request.ImgUrl, request.WarrantyUrl, request.InstructionManualUrl, request.LocationId, companyId), _putAssetPresenter);
            return _putAssetPresenter.ContentResult;
        }
    }
}