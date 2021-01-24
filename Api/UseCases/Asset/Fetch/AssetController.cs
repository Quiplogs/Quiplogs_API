namespace Api.UseCases.Asset.Fetch
{
    public class AssetController : BaseApiController
    {
        //private readonly IFetchAssetUseCase _fetchAssetUseCase;
        //private readonly FetchAssetPresenter _fetchAssetPresenter;

        //public AssetController(IFetchAssetUseCase fetchAssetUseCase, FetchAssetPresenter fetchAssetPresenter)
        //{
        //    _fetchAssetUseCase = fetchAssetUseCase;
        //    _fetchAssetPresenter = fetchAssetPresenter;
        //}

        //[HttpGet("List")]
        //public async Task<ActionResult> List([FromQuery] FetchAssetRequest request)
        //{
        //    if (!ModelState.IsValid)
        //    { // re-render the view when validation failed.
        //        return BadRequest(ModelState);
        //    }

        //    var companyId = request.CompanyId;
        //    if (string.IsNullOrEmpty(companyId))
        //    {
        //        companyId = this.GetCompanyId();
        //    }

        //    await _fetchAssetUseCase.Handle(new Quiplogs.Assets.Dto.Requests.Asset.FetchAssetRequest(companyId, request.LocationId, request.PageNumber), _fetchAssetPresenter);
        //    return _fetchAssetPresenter.ContentResult;
        //}
    }
}