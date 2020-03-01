using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Quiplogs.WorkOrder.Interfaces.UseCases.PlannedMaintenanceTask;

namespace Api.UseCases.PlannedMaintenanceTask.Put
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    //[Authorize]
    [ApiController]
    public class PlannedMaintenanceTaskController : ControllerBase
    {
        private readonly IPutPlannedMaintenanceTaskUseCase _putPlannedMaintenanceTaskUseCase;
        private readonly PutPlannedMaintenanceTaskPresenter _putPlannedMaintenanceTaskPresenter;

        public PlannedMaintenanceTaskController(IPutPlannedMaintenanceTaskUseCase putPlannedMaintenanceTaskUseCase, PutPlannedMaintenanceTaskPresenter putPlannedMaintenanceTaskPresenter)
        {
            _putPlannedMaintenanceTaskUseCase = putPlannedMaintenanceTaskUseCase;
            _putPlannedMaintenanceTaskPresenter = putPlannedMaintenanceTaskPresenter;
        }

        [HttpPut("Put")]
        public async Task<ActionResult> Put([FromBody] PutPlannedMaintenanceTaskRequest request)
        {
            if (!ModelState.IsValid)
            { // re-render the view when validation failed.
                return BadRequest(ModelState);
            }
            await _putPlannedMaintenanceTaskUseCase.Handle(new Quiplogs.WorkOrder.Dto.Requests.PlannedMaintenanceTask.PutPlannedMaintenanceTaskRequest(request.PlannedMaintenanceTask), _putPlannedMaintenanceTaskPresenter);
            return _putPlannedMaintenanceTaskPresenter.ContentResult;
        }
    }
}