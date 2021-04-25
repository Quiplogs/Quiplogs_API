using Api.Presenters;
using Api.UseCases.Generic.Requests;
using Microsoft.AspNetCore.Mvc;
using Quiplogs.WorkOrder.UseCases.WorkOrderPart;
using System.Threading.Tasks;

namespace Api.UseCases.WorkOrderPart.Put
{
    public class WorkOrderPartController : BaseApiController
    {
        private readonly PutWorkOrderPartUseCase _putUseCase;
        private readonly PutPresenter<Quiplogs.WorkOrder.Domain.Entities.WorkOrderPart> _putPresenter;

        public WorkOrderPartController(PutWorkOrderPartUseCase putUseCase, PutPresenter<Quiplogs.WorkOrder.Domain.Entities.WorkOrderPart> putPresenter)
        {
            _putUseCase = putUseCase;
            _putPresenter = putPresenter;
        }

        [HttpPut()]
        public async Task<ActionResult> Put([FromBody] PutRequest<Quiplogs.WorkOrder.Domain.Entities.WorkOrderPart> request)
        {
            if (!ModelState.IsValid)
            {
                // re-render the view when validation failed.
                return BadRequest(ModelState);
            }

            request.Model.CompanyId = GetCompanyId(request.Model.CompanyId);

            await _putUseCase.Handle(new Quiplogs.Core.Dto.Requests.Generic.PutRequest<Quiplogs.WorkOrder.Domain.Entities.WorkOrderPart>(request.Model), _putPresenter);
            return _putPresenter.ContentResult;
        }
    }
}