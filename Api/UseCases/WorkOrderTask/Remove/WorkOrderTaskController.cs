using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Quiplogs.WorkOrder.Interfaces.UseCases.WorkOrderTask;

namespace Api.UseCases.WorkOrderTask.Remove
{
    public class WorkOrderTaskController : BaseApiController
    {
        private readonly IRemoveWorkOrderTaskUseCase _removeWorkOrderTaskUseCase;
        private readonly RemoveWorkOrderTaskPresenter _removeWorkOrderTaskPresenter;

        public WorkOrderTaskController(IRemoveWorkOrderTaskUseCase removeWorkOrderTaskUseCase, RemoveWorkOrderTaskPresenter removeWorkOrderTaskPresenter)
        {
            _removeWorkOrderTaskUseCase = removeWorkOrderTaskUseCase;
            _removeWorkOrderTaskPresenter = removeWorkOrderTaskPresenter;
        }

        [HttpDelete()]
        public async Task<ActionResult> Remove([FromBody] RemoveWorkOrderTaskRequest request)
        {
            if (!ModelState.IsValid)
            { // re-render the view when validation failed.
                return BadRequest(ModelState);
            }
            await _removeWorkOrderTaskUseCase.Handle(new Quiplogs.WorkOrder.Dto.Requests.WorkOrderTask.RemoveWorkOrderTaskRequest(request.Id), _removeWorkOrderTaskPresenter);
            return _removeWorkOrderTaskPresenter.ContentResult;
        }
    }
}