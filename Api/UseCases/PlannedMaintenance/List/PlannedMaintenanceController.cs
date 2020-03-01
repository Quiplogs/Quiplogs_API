using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Quiplogs.PlannedMaintenance.Interfaces.UseCases.PlannedMaintenance;

namespace Api.UseCases.PlannedMaintenance.List
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    //[Authorize]
    [ApiController]
    public class PlannedMaintenanceController : ControllerBase
    {
        private readonly IListPlannedMaintenanceUseCase _listPlannedMaintenanceUseCase;
        private readonly ListPlannedMaintenancePresenter _listPlannedMaintenancePresenter;

        public PlannedMaintenanceController(IListPlannedMaintenanceUseCase listPlannedMaintenanceUseCase, ListPlannedMaintenancePresenter listPlannedMaintenancePresenter)
        {
            _listPlannedMaintenanceUseCase = listPlannedMaintenanceUseCase;
            _listPlannedMaintenancePresenter = listPlannedMaintenancePresenter;
        }

        [HttpGet("List")]
        public async Task<ActionResult> List([FromQuery] ListPlannedMaintenanceRequest request)
        {
            if (!ModelState.IsValid)
            { // re-render the view when validation failed.
                return BadRequest(ModelState);
            }
            await _listPlannedMaintenanceUseCase.Handle(new Quiplogs.WorkOrder.Dto.Requests.PlannedMaintenance.ListPlannedMaintenanceRequest(request.CompanyId, request.LocationId, request.AssetId, request.PageNumber), _listPlannedMaintenancePresenter);
            return _listPlannedMaintenancePresenter.ContentResult;
        }
    }
}