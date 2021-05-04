using Api.Presenters;
using Api.UseCases.Generic.Requests;
using Microsoft.AspNetCore.Mvc;
using Quiplogs.Core.Dto.Requests.Generic;
using Quiplogs.PlannedMaintenance.UseCases.PlannedMaintenance;
using System.Threading.Tasks;

namespace Api.UseCases.PlannedMaintenance.List
{
    public class PlannedMaintenanceController : BaseApiController
    {
        private readonly PlannedMaintenancePagedListUseCase _pagedListUseCase;
        private readonly PagedListPresenter<Quiplogs.PlannedMaintenance.Domain.Entities.PlannedMaintenance> _pagedListPresenter;

        public PlannedMaintenanceController(PlannedMaintenancePagedListUseCase pagedListUseCase, PagedListPresenter<Quiplogs.PlannedMaintenance.Domain.Entities.PlannedMaintenance> pagedListPresenter)
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

            await _pagedListUseCase.Handle(new PagedRequest<Quiplogs.PlannedMaintenance.Domain.Entities.PlannedMaintenance>(GetCompanyId(request.CompanyId), request.LocationId, request.ParentId, request.PageNumber, request.PageSize, request.FilterParameters), _pagedListPresenter);
            return _pagedListPresenter.ContentResult;
        }
    }
}