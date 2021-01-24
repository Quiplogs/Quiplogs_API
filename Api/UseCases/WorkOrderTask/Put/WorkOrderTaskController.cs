using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Quiplogs.WorkOrder.Interfaces.UseCases.WorkOrderTask;

namespace Api.UseCases.WorkOrderTask.Put
{
    public class WorkOrderTaskController : BaseApiController
    {
        private readonly IPutWorkOrderTaskUseCase _putWorkOrderTaskUseCase;
        private readonly PutWorkOrderTaskPresenter _putWorkOrderTaskPresenter;

        public WorkOrderTaskController(IPutWorkOrderTaskUseCase putWorkOrderTaskUseCase, PutWorkOrderTaskPresenter putWorkOrderTaskPresenter)
        {
            _putWorkOrderTaskUseCase = putWorkOrderTaskUseCase;
            _putWorkOrderTaskPresenter = putWorkOrderTaskPresenter;
        }

        [HttpPut()]
        public async Task<ActionResult> Put([FromBody] PutWorkOrderTaskRequest request)
        {
            if (!ModelState.IsValid)
            { // re-render the view when validation failed.
                return BadRequest(ModelState);
            }

            await _putWorkOrderTaskUseCase.Handle(new Quiplogs.WorkOrder.Dto.Requests.WorkOrderTask.PutWorkOrderTaskRequest(request.WorkOrderTask), _putWorkOrderTaskPresenter);
            return _putWorkOrderTaskPresenter.ContentResult;
        }
    }
}