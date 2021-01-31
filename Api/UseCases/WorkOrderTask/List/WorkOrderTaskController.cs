using Api.Presenters;
using Microsoft.AspNetCore.Mvc;
using Quiplogs.Core.Dto.Requests.Generic;
using Quiplogs.WorkOrder.UseCases.WorkOrderTask;
using System.Threading.Tasks;

namespace Api.UseCases.WorkOrderTask.List
{
    public class WorkOrderTaskController : BaseApiController
    {
        private readonly ListWorkOrderTaskUseCase _listUseCase;
        private readonly ListPresenter<Quiplogs.WorkOrder.Domain.Entities.WorkOrderTask> _listPresenter;

        public WorkOrderTaskController(ListWorkOrderTaskUseCase listUseCase, ListPresenter<Quiplogs.WorkOrder.Domain.Entities.WorkOrderTask> listPresenter)
        {
            _listUseCase = listUseCase;
            _listPresenter = listPresenter;
        }

        [HttpPost("ListByParent")]
        public async Task<ActionResult> PagedList([FromBody] ListRequest<Quiplogs.WorkOrder.Domain.Entities.WorkOrderTask> request)
        {
            if (!ModelState.IsValid)
            {
                // re-render the view when validation failed.
                return BadRequest(ModelState);
            }

            await _listUseCase.Handle(new ListRequest<Quiplogs.WorkOrder.Domain.Entities.WorkOrderTask>(request.CompanyId, request.LocationId, request.ParentId, request.FilterParameters), _listPresenter);
            return _listPresenter.ContentResult;
        }
    }
}