using Api.Presenters;
using Microsoft.AspNetCore.Mvc;
using Quiplogs.Core.Dto.Requests.Generic;
using Quiplogs.WorkOrder.UseCases.WorkOrderPart;
using System.Threading.Tasks;

namespace Api.UseCases.WorkOrderPart.List
{
    public class WorkOrderPartController : BaseApiController
    {
        private readonly ListWorkOrderPartUseCase _listUseCase;
        private readonly ListPresenter<Quiplogs.WorkOrder.Domain.Entities.WorkOrderPart> _listPresenter;

        public WorkOrderPartController(ListWorkOrderPartUseCase listUseCase, ListPresenter<Quiplogs.WorkOrder.Domain.Entities.WorkOrderPart> listPresenter)
        {
            _listUseCase = listUseCase;
            _listPresenter = listPresenter;
        }

        [HttpPost("ListByParent")]
        public async Task<ActionResult> PagedList([FromBody] ListRequest<Quiplogs.WorkOrder.Domain.Entities.WorkOrderPart> request)
        {
            if (!ModelState.IsValid)
            {
                // re-render the view when validation failed.
                return BadRequest(ModelState);
            }

            await _listUseCase.Handle(new ListRequest<Quiplogs.WorkOrder.Domain.Entities.WorkOrderPart>(request.CompanyId, request.LocationId, request.ParentId, request.FilterParameters), _listPresenter);
            return _listPresenter.ContentResult;
        }
    }
}