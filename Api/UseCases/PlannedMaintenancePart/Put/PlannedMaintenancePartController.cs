using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Quiplogs.WorkOrder.Interfaces.UseCases.PlannedMaintenancePart;

namespace Api.UseCases.PlannedMaintenancePart.Put
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    //[Authorize]
    [ApiController]
    public class PlannedMaintenancePartController : ControllerBase
    {
        private readonly IPutPlannedMaintenancePartUseCase _putPlannedMaintenancePartUseCase;
        private readonly PutPlannedMaintenancePartPresenter _putPlannedMaintenancePartPresenter;

        public PlannedMaintenancePartController(IPutPlannedMaintenancePartUseCase putPlannedMaintenancePartUseCase, PutPlannedMaintenancePartPresenter putPlannedMaintenancePartPresenter)
        {
            _putPlannedMaintenancePartUseCase = putPlannedMaintenancePartUseCase;
            _putPlannedMaintenancePartPresenter = putPlannedMaintenancePartPresenter;
        }

        [HttpPut("Put")]
        public async Task<ActionResult> Put([FromBody] PutPlannedMaintenancePartRequest request)
        {
            if (!ModelState.IsValid)
            { // re-render the view when validation failed.
                return BadRequest(ModelState);
            }
            await _putPlannedMaintenancePartUseCase.Handle(new Quiplogs.WorkOrder.Dto.Requests.PlannedMaintenancePart.PutPlannedMaintenancePartRequest(request.PlannedMaintenancePart), _putPlannedMaintenancePartPresenter);
            return _putPlannedMaintenancePartPresenter.ContentResult;
        }
    }
}