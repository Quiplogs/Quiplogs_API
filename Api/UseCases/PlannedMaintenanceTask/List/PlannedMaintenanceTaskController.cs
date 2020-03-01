using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Quiplogs.WorkOrder.Interfaces.UseCases.PlannedMaintenanceTask;

namespace Api.UseCases.PlannedMaintenanceTask.List
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    //[Authorize]
    [ApiController]
    public class PlannedMaintenanceTaskController : ControllerBase
    {
        private readonly IListPlannedMaintenanceTaskUseCase _listPlannedMaintenanceTaskUseCase;
        private readonly ListPlannedMaintenanceTaskPresenter _listPlannedMaintenanceTaskPresenter;

        public PlannedMaintenanceTaskController(IListPlannedMaintenanceTaskUseCase listPlannedMaintenanceTaskUseCase, ListPlannedMaintenanceTaskPresenter listPlannedMaintenanceTaskPresenter)
        {
            _listPlannedMaintenanceTaskUseCase = listPlannedMaintenanceTaskUseCase;
            _listPlannedMaintenanceTaskPresenter = listPlannedMaintenanceTaskPresenter;
        }

        [HttpGet("List")]
        public async Task<ActionResult> List([FromQuery] ListPlannedMaintenanceTaskRequest request)
        {
            if (!ModelState.IsValid)
            { // re-render the view when validation failed.
                return BadRequest(ModelState);
            }
            await _listPlannedMaintenanceTaskUseCase.Handle(new Quiplogs.WorkOrder.Dto.Requests.PlannedMaintenanceTask.ListPlannedMaintenanceTaskRequest(request.PlannedMaintenanceId, request.PageNumber), _listPlannedMaintenanceTaskPresenter);
            return _listPlannedMaintenanceTaskPresenter.ContentResult;
        }
    }
}