using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Quiplogs.WorkOrder.Interfaces.UseCases.WorkOrderTask;

namespace Api.UseCases.WorkOrderTask.Put
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    //[Authorize]
    [ApiController]
    public class WorkOrderTaskController : ControllerBase
    {
        private readonly IPutWorkOrderTaskUseCase _putWorkOrderTaskUseCase;
        private readonly PutWorkOrderTaskPresenter _putWorkOrderTaskPresenter;

        public WorkOrderTaskController(IPutWorkOrderTaskUseCase putWorkOrderTaskUseCase, PutWorkOrderTaskPresenter putWorkOrderTaskPresenter)
        {
            _putWorkOrderTaskUseCase = putWorkOrderTaskUseCase;
            _putWorkOrderTaskPresenter = putWorkOrderTaskPresenter;
        }

        [HttpPut("Put")]
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