using Api.Presenters;
using Api.UseCases.Generic.Requests;
using Microsoft.AspNetCore.Mvc;
using Quiplogs.Assets.UseCases.Asset;
using System.Threading.Tasks;
using Quiplogs.Core.Dto.Requests.Generic;

namespace Api.UseCases.Asset.List
{
    public class AssetController : BaseApiController
    {
        private readonly AssetPagedListUseCase _pagedListUseCase;
        private readonly PagedListPresenter<Quiplogs.Assets.Domain.Entities.Asset> _pagedListPresenter;

        public AssetController(AssetPagedListUseCase pagedListUseCase, PagedListPresenter<Quiplogs.Assets.Domain.Entities.Asset> pagedListPresenter)
        {
            _pagedListUseCase = pagedListUseCase;
            _pagedListPresenter = pagedListPresenter;
        }

        [HttpPost("PagedList")]
        public async Task<ActionResult> PagedList([FromBody] PagedListRequest request)
        {
            if (!ModelState.IsValid)
            {
                // re-render the view when validation failed.
                return BadRequest(ModelState);
            }

            await _pagedListUseCase.Handle(new PagedRequest<Quiplogs.Assets.Domain.Entities.Asset>(GetCompanyId(request.CompanyId), request.LocationId, request.ParentId, request.PageNumber, request.PageSize, request.FilterParameters), _pagedListPresenter);
            return _pagedListPresenter.ContentResult;
        }
    }
}