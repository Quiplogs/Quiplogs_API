using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Quiplogs.WorkOrder.Interfaces.UseCases.PlannedMaintenance;

namespace Api.UseCases.PlannedMaintenance.List
{
    public class PlannedMaintenanceController : BaseApiController
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

            await _listPlannedMaintenanceUseCase.Handle(new Quiplogs.WorkOrder.Dto.Requests.PlannedMaintenance.ListPlannedMaintenanceRequest(GetCompanyId(request.CompanyId), request.LocationId, request.AssetId, request.ShouldPage, request.PageNumber), _listPlannedMaintenancePresenter);
            return _listPlannedMaintenancePresenter.ContentResult;
        }
    }
}