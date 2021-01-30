﻿using Api.Services.Interfaces;
using Api.UseCases.Generic.Requests;
using Microsoft.AspNetCore.Mvc;
using Quiplogs.WorkOrder.Data.Entities;
using System.Threading.Tasks;

namespace Api.UseCases.PlannedMaintenancePart.Put
{
    public class PlannedMaintenancePartController : BaseApiController
    {
        private readonly IPutService<Quiplogs.WorkOrder.Domain.Entities.PlannedMaintenancePart, PlannedMaintenancePartDto> _putService;

        public PlannedMaintenancePartController(IPutService<Quiplogs.WorkOrder.Domain.Entities.PlannedMaintenancePart, PlannedMaintenancePartDto> putService)
        {
            _putService = putService;
        }

        [HttpPut()]
        public async Task<ActionResult> Put([FromBody] PutRequest<Quiplogs.WorkOrder.Domain.Entities.PlannedMaintenancePart> request)
        {
            if (!ModelState.IsValid)
            {
                // re-render the view when validation failed.
                return BadRequest(ModelState);
            }

            var result = await _putService.Put(request);
            return result;
        }
    }
}