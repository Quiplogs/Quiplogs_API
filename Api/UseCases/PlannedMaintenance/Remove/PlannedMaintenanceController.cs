﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Quiplogs.PlannedMaintenance.Interfaces.UseCases.PlannedMaintenance;

namespace Api.UseCases.PlannedMaintenance.Remove
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    //[Authorize]
    [ApiController]
    public class PlannedMaintenanceController : ControllerBase
    {
        private readonly IRemovePlannedMaintenanceUseCase _removePlannedMaintenanceUseCase;
        private readonly RemovePlannedMaintenancePresenter _removePlannedMaintenancePresenter;

        public PlannedMaintenanceController(IRemovePlannedMaintenanceUseCase removePlannedMaintenanceUseCase, RemovePlannedMaintenancePresenter removePlannedMaintenancePresenter)
        {
            _removePlannedMaintenanceUseCase = removePlannedMaintenanceUseCase;
            _removePlannedMaintenancePresenter = removePlannedMaintenancePresenter;
        }

        [HttpPost("Remove")]
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