using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Quiplogs.Assets.Interfaces.UseCases.AssetUsage;

namespace Api.UseCases.AssetUsage.List
{
    public class AssetUsageController : BaseApiController
    {
        //private readonly IListAssetUsageUseCase _useCase;
        //private readonly ListAssetUsagePresenter _presenter;

        //public AssetUsageController(IListAssetUsageUseCase useCase, ListAssetUsagePresenter presenter)
        //{
        //    _useCase = useCase;
        //    _presenter = presenter;
        //}

        //[HttpGet("List")]
        //public async Task<ActionResult> List([FromQuery] ListAssetUsageRequest request)
        //{
        //    if (!ModelState.IsValid)
        //    { // re-render the view when validation failed.
        //        return BadRequest(ModelState);
        //    }

        //    await _useCase.Handle(new Quiplogs.Assets.Dto.Requests.AssetUsage.ListAssetUsageRequest(request.AssetId, request.PageNumber), _presenter);
        //    return _presenter.ContentResult;
        //}
    }
}
