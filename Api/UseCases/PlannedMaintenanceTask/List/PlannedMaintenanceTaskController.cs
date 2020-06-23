using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Quiplogs.WorkOrder.Interfaces.UseCases.PlannedMaintenanceTask;

namespace Api.UseCases.PlannedMaintenanceTask.List
{
    public class PlannedMaintenanceTaskController : BaseApiController
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

            await _listPlannedMaintenanceTaskUseCase.Handle(new Quiplogs.WorkOrder.Dto.Requests.PlannedMaintenanceTask.ListPlannedMaintenanceTaskRequest(request.PlannedMaintenanceId), _listPlannedMaintenanceTaskPresenter);
            return _listPlannedMaintenanceTaskPresenter.ContentResult;
        }
    }
}