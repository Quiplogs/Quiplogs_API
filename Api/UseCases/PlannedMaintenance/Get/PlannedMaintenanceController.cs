using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Quiplogs.WorkOrder.Interfaces.UseCases.PlannedMaintenance;

namespace Api.UseCases.PlannedMaintenance.Get
{
    public class PlannedMaintenanceController : BaseApiController
    {
        private readonly IGetPlannedMaintenanceUseCase _getPlannedMaintenanceUseCase;
        private readonly GetPlannedMaintenancePresenter _getPlannedMaintenancePresenter;

        public PlannedMaintenanceController(IGetPlannedMaintenanceUseCase getPlannedMaintenanceUseCase, GetPlannedMaintenancePresenter getPlannedMaintenancePresenter)
        {
            _getPlannedMaintenanceUseCase = getPlannedMaintenanceUseCase;
            _getPlannedMaintenancePresenter = getPlannedMaintenancePresenter;
        }

        [HttpGet()]
        public async Task<ActionResult> Get([FromQuery] GetPlannedMaintenanceRequest request)
        {
            if (!ModelState.IsValid)
            { // re-render the view when validation failed.
                return BadRequest(ModelState);
            }

            await _getPlannedMaintenanceUseCase.Handle(new Quiplogs.WorkOrder.Dto.Requests.PlannedMaintenance.GetPlannedMaintenanceRequest(request.Id), _getPlannedMaintenancePresenter);
            return _getPlannedMaintenancePresenter.ContentResult;
        }
    }
}