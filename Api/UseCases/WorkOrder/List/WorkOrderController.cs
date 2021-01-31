using Api.Presenters;
using Api.UseCases.Generic.Requests;
using Microsoft.AspNetCore.Mvc;
using Quiplogs.Core.Dto.Requests.Generic;
using Quiplogs.WorkOrder.Domain.Entities;
using Quiplogs.WorkOrder.UseCases.WorkOrder;
using System.Threading.Tasks;

namespace Api.UseCases.WorkOrder.List
{
    public class WorkOrderController : BaseApiController
    {
        private readonly WorkOrderPagedListUseCase _pagedListUseCase;
        private readonly PagedListPresenter<WorkOrderEntity> _pagedListPresenter;

        public WorkOrderController(WorkOrderPagedListUseCase pagedListUseCase, PagedListPresenter<WorkOrderEntity> pagedListPresenter)
        {
            _pagedListUseCase = pagedListUseCase;
            _pagedListPresenter = pagedListPresenter;
        }

        [HttpPost("PagedList")]
        public async Task<ActionResult> PagedList([FromBody] PagedListRequest<WorkOrderEntity> request)
        {
            if (!ModelState.IsValid)
            {
                // re-render the view when validation failed.
                return BadRequest(ModelState);
            }

            await _pagedListUseCase.Handle(new PagedRequest<WorkOrderEntity>(request.CompanyId, request.LocationId, request.ParentId, request.PageNumber, request.PageSize, request.FilterParameters), _pagedListPresenter);
            return _pagedListPresenter.ContentResult;
        }
    }
}