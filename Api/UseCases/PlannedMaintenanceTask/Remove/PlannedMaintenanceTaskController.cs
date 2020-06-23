using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Quiplogs.WorkOrder.Interfaces.UseCases.PlannedMaintenanceTask;

namespace Api.UseCases.PlannedMaintenanceTask.Remove
{
    public class PlannedMaintenanceTaskController : BaseApiController
    {
        private readonly IRemovePlannedMaintenanceTaskUseCase _removePlannedMaintenanceTaskUseCase;
        private readonly RemovePlannedMaintenanceTaskPresenter _removePlannedMaintenanceTaskPresenter;

        public PlannedMaintenanceTaskController(IRemovePlannedMaintenanceTaskUseCase removePlannedMaintenanceTaskUseCase, RemovePlannedMaintenanceTaskPresenter removePlannedMaintenanceTaskPresenter)
        {
            _removePlannedMaintenanceTaskUseCase = removePlannedMaintenanceTaskUseCase;
            _removePlannedMaintenanceTaskPresenter = removePlannedMaintenanceTaskPresenter;
        }

        [HttpDelete()]
        public async Task<ActionResult> Remove([FromQuery] RemovePlannedMaintenanceTaskRequest request)
        {
            if (!ModelState.IsValid)
            { // re-render the view when validation failed.
                return BadRequest(ModelState);
            }

            await _removePlannedMaintenanceTaskUseCase.Handle(new Quiplogs.WorkOrder.Dto.Requests.PlannedMaintenanceTask.RemovePlannedMaintenanceTaskRequest(request.Id), _removePlannedMaintenanceTaskPresenter);
            return _removePlannedMaintenanceTaskPresenter.ContentResult;
        }
    }
}