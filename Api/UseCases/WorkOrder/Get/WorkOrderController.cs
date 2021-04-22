using Api.Presenters;
using Api.UseCases.Generic.Requests;
using Microsoft.AspNetCore.Mvc;
using Quiplogs.WorkOrder.Domain.Entities;
using Quiplogs.WorkOrder.UseCases.WorkOrder;
using System.Threading.Tasks;
using Quiplogs.Core.Dto.Requests.Generic;

namespace Api.UseCases.WorkOrder.Get
{
    public class WorkOrderController : BaseApiController
    {
        private readonly GetWorkOrderUseCase _getUseCase;
        private readonly GetPresenter<WorkOrderEntity> _presenter;

        public WorkOrderController(GetWorkOrderUseCase getUseCase, GetPresenter<WorkOrderEntity> presenter)
        {
            _getUseCase = getUseCase;
            _presenter = presenter;
        }

        [HttpGet()]
        public async Task<ActionResult> Get([FromQuery] GetRequest request)
        {
            if (!ModelState.IsValid)
            {
                // re-render the view when validation failed.
                return BadRequest(ModelState);
            }

            await _getUseCase.Handle(new GetRequest<WorkOrderEntity>(request.Id), _presenter);
            return _presenter.ContentResult;
        }
    }
}