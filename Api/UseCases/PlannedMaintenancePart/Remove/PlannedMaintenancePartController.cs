using Api.UseCases.PlannedMaintenancePart.Remove;
using Microsoft.AspNetCore.Mvc;
using Quiplogs.WorkOrder.Interfaces.UseCases.PlannedMaintenancePart;
using System.Threading.Tasks;

namespace Api.UseCases.PlannedMaintenancePartPart.Remove
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    //[Authorize]
    [ApiController]
    public class PlannedMaintenancePartController : ControllerBase
    {
        private readonly IRemovePlannedMaintenancePartUseCase _removePlannedMaintenancePartUseCase;
        private readonly RemovePlannedMaintenancePartPresenter _removePlannedMaintenancePartPresenter;

        public PlannedMaintenancePartController(IRemovePlannedMaintenancePartUseCase removePlannedMaintenancePartUseCase, RemovePlannedMaintenancePartPresenter removePlannedMaintenancePartPresenter)
        {
            _removePlannedMaintenancePartUseCase = removePlannedMaintenancePartUseCase;
            _removePlannedMaintenancePartPresenter = removePlannedMaintenancePartPresenter;
        }

        [HttpPost("Remove")]
        public async Task<ActionResult> Remove([FromBody] RemovePlannedMaintenancePartRequest request)
        {
            if (!ModelState.IsValid)
            { // re-render the view when validation failed.
                return BadRequest(ModelState);
            }
            await _removePlannedMaintenancePartUseCase.Handle(new Quiplogs.WorkOrder.Dto.Requests.PlannedMaintenancePart.RemovePlannedMaintenancePartRequest(request.Id), _removePlannedMaintenancePartPresenter);
            return _removePlannedMaintenancePartPresenter.ContentResult;
        }
    }
}