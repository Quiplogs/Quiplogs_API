using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Quiplogs.WorkOrder.Interfaces.UseCases.PlannedMaintenancePart;

namespace Api.UseCases.PlannedMaintenancePart.List
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    //[Authorize]
    [ApiController]
    public class PlannedMaintenancePartController : ControllerBase
    {
        private readonly IListPlannedMaintenancePartUseCase _listPlannedMaintenancePartUseCase;
        private readonly ListPlannedMaintenancePartPresenter _listPlannedMaintenancePartPresenter;

        public PlannedMaintenancePartController(IListPlannedMaintenancePartUseCase listPlannedMaintenancePartUseCase, ListPlannedMaintenancePartPresenter listPlannedMaintenancePartPresenter)
        {
            _listPlannedMaintenancePartUseCase = listPlannedMaintenancePartUseCase;
            _listPlannedMaintenancePartPresenter = listPlannedMaintenancePartPresenter;
        }

        [HttpGet("List")]
        public async Task<ActionResult> List([FromQuery] ListPlannedMaintenancePartRequest request)
        {
            if (!ModelState.IsValid)
            { // re-render the view when validation failed.
                return BadRequest(ModelState);
            }
            await _listPlannedMaintenancePartUseCase.Handle(new Quiplogs.WorkOrder.Dto.Requests.PlannedMaintenancePart.ListPlannedMaintenancePartRequest(request.PlannedMaintenanceId, request.PageNumber), _listPlannedMaintenancePartPresenter);
            return _listPlannedMaintenancePartPresenter.ContentResult;
        }
    }
}