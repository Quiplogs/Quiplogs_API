using Api.Presenters;
using Api.UseCases.Generic.Requests;
using Microsoft.AspNetCore.Mvc;
using Quiplogs.WorkOrder.Domain.Entities;
using Quiplogs.WorkOrder.UseCases.WorkOrder;
using System.Threading.Tasks;

namespace Api.UseCases.WorkOrder.Put
{
    public class WorkOrderController : BaseApiController
    {
        private readonly PutWorkOrderUseCase _putUseCase;
        private readonly PutPresenter<WorkOrderEntity> _putPresenter;

        public WorkOrderController(PutWorkOrderUseCase putUseCase, PutPresenter<WorkOrderEntity> putPresenter)
        {
            _putUseCase = putUseCase;
            _putPresenter = putPresenter;
        }

        [HttpPut()]
        public async Task<ActionResult> Put([FromBody] PutRequest<WorkOrderEntity> request)
        {
            if (!ModelState.IsValid)
            {
                // re-render the view when validation failed.
                return BadRequest(ModelState);
            }

            request.Model.CompanyId = GetCompanyId(request.Model.CompanyId);

            await _putUseCase.Handle(new Quiplogs.Core.Dto.Requests.Generic.PutRequest<WorkOrderEntity>(request.Model), _putPresenter);
            return _putPresenter.ContentResult;
        }
    }
}