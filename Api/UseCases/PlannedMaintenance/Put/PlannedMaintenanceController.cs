﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Quiplogs.PlannedMaintenance.Interfaces.UseCases.PlannedMaintenance;

namespace Api.UseCases.PlannedMaintenance.Put
{
    public class PlannedMaintenanceController : BaseApiController
    {
        private readonly IPutPlannedMaintenanceUseCase _putPlannedMaintenanceUseCase;
        private readonly PutPlannedMaintenancePresenter _putPlannedMaintenancePresenter;

        public PlannedMaintenanceController(IPutPlannedMaintenanceUseCase putPlannedMaintenanceUseCase, PutPlannedMaintenancePresenter putPlannedMaintenancePresenter)
        {
            _putPlannedMaintenanceUseCase = putPlannedMaintenanceUseCase;
            _putPlannedMaintenancePresenter = putPlannedMaintenancePresenter;
        }

        [HttpPut()]
        public async Task<ActionResult> Put([FromBody] PutPlannedMaintenanceRequest request)
        {
            if (!ModelState.IsValid)
            { // re-render the view when validation failed.
                return BadRequest(ModelState);
            }

            var companyId = request.CompanyId;
            if (string.IsNullOrEmpty(companyId))
            {
                companyId = this.GetCompanyId();
            }

            await _putPlannedMaintenanceUseCase.Handle(new Quiplogs.WorkOrder.Dto.Requests.PlannedMaintenance.PutPlannedMaintenanceRequest(request.AssetId, companyId, request.Cycles, request.IsRecurring, request.UoM), _putPlannedMaintenancePresenter);
            return _putPlannedMaintenancePresenter.ContentResult;
        }
    }
}