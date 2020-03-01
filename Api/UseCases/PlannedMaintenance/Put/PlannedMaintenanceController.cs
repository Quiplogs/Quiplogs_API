using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Quiplogs.PlannedMaintenance.Interfaces.UseCases.PlannedMaintenance;

namespace Api.UseCases.PlannedMaintenance.Put
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    //[Authorize]
    [ApiController]
    public class PlannedMaintenanceController : ControllerBase
    {
        private readonly IPutPlannedMaintenanceUseCase _putPlannedMaintenanceUseCase;
        private readonly PutPlannedMaintenancePresenter _putPlannedMaintenancePresenter;

        public PlannedMaintenanceController(IPutPlannedMaintenanceUseCase putPlannedMaintenanceUseCase, PutPlannedMaintenancePresenter putPlannedMaintenancePresenter)
        {
            _putPlannedMaintenanceUseCase = putPlannedMaintenanceUseCase;
            _putPlannedMaintenancePresenter = putPlannedMaintenancePresenter;
        }

        [HttpPut("Put")]
        public async Task<ActionResult> Put([FromBody] PutPlannedMaintenanceRequest request)
        {
            if (!ModelState.IsValid)
            { // re-render the view when validation failed.
                return BadRequest(ModelState);
            }
            await _putPlannedMaintenanceUseCase.Handle(new Quiplogs.WorkOrder.Dto.Requests.PlannedMaintenance.PutPlannedMaintenanceRequest(request.PlannedMaintenance), _putPlannedMaintenancePresenter);
            return _putPlannedMaintenancePresenter.ContentResult;
        }
    }
}