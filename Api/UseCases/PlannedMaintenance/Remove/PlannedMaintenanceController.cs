using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Quiplogs.WorkOrder.Interfaces.UseCases.PlannedMaintenance;

namespace Api.UseCases.PlannedMaintenance.Remove
{
    public class PlannedMaintenanceController : BaseApiController
    {
        private readonly IRemovePlannedMaintenanceUseCase _removePlannedMaintenanceUseCase;
        private readonly RemovePlannedMaintenancePresenter _removePlannedMaintenancePresenter;

        public PlannedMaintenanceController(IRemovePlannedMaintenanceUseCase removePlannedMaintenanceUseCase, RemovePlannedMaintenancePresenter removePlannedMaintenancePresenter)
        {
            _removePlannedMaintenanceUseCase = removePlannedMaintenanceUseCase;
            _removePlannedMaintenancePresenter = removePlannedMaintenancePresenter;
        }

        [HttpDelete()]
        public async Task<ActionResult> Remove([FromBody] RemovePlannedMaintenanceRequest request)
        {
            if (!ModelState.IsValid)
            { // re-render the view when validation failed.
                return BadRequest(ModelState);
            }
            await _removePlannedMaintenanceUseCase.Handle(new Quiplogs.WorkOrder.Dto.Requests.PlannedMaintenance.RemovePlannedMaintenanceRequest(request.Id), _removePlannedMaintenancePresenter);
            return _removePlannedMaintenancePresenter.ContentResult;
        }
    }
}