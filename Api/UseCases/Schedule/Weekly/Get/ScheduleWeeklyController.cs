﻿using Api.Services.Interfaces;
using Api.UseCases.Generic.Requests;
using Microsoft.AspNetCore.Mvc;
using Quiplogs.Schedules.Data.Entities;
using System.Threading.Tasks;

namespace Api.UseCases.Schedule.Weekly.Get
{
    public class ScheduleWeeklyController : BaseApiController
    {
        private readonly IGetService<Quiplogs.Schedules.Domain.Entities.ScheduleWeekly, ScheduleWeeklyDto> _getService;

        public ScheduleWeeklyController(IGetService<Quiplogs.Schedules.Domain.Entities.ScheduleWeekly, ScheduleWeeklyDto> getService)
        {
            _getService = getService;
        }

        [HttpGet()]
        public async Task<ActionResult> Get([FromQuery] GetRequest request)
        {
            if (!ModelState.IsValid)
            {
                // re-render the view when validation failed.
                return BadRequest(ModelState);
            }

            var result = await _getService.Get(request);
            return result;
        }
    }
}
