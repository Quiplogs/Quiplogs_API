using Api.Presenters;
using Api.UseCases.Generic.Requests;
using Microsoft.AspNetCore.Mvc;
using Quiplogs.Assets.UseCases.AssetUsage;
using Quiplogs.Core.Dto.Requests.Generic;
using System.Threading.Tasks;

namespace Api.UseCases.AssetUsage.List
{
    public class AssetUsageController : BaseApiController
    {
        private readonly AssetUsagePagedListUseCase _pagedListUseCase;
        private readonly PagedListPresenter<Quiplogs.Assets.Domain.Entities.AssetUsage> _pagedListPresenter;

        public AssetUsageController(AssetUsagePagedListUseCase pagedListUseCase, PagedListPresenter<Quiplogs.Assets.Domain.Entities.AssetUsage> pagedListPresenter)
        {
            _pagedListUseCase = pagedListUseCase;
            _pagedListPresenter = pagedListPresenter;
        }

        [HttpPost("ListByParent")]
        public async Task<ActionResult> PagedList([FromBody] PagedListRequest request)
        {
            if (!ModelState.IsValid)
            {
                // re-render the view when validation failed.
                return BadRequest(ModelState);
            }

            await _pagedListUseCase.Handle(new PagedRequest<Quiplogs.Assets.Domain.Entities.AssetUsage>(GetCompanyId(request.CompanyId), request.LocationId, request.ParentId, request.PageNumber, request.PageSize, request.FilterParameters), _pagedListPresenter);
            return _pagedListPresenter.ContentResult;
        }
    }
}
