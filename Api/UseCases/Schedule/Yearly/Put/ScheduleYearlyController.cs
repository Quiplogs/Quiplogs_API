using System;
using Api.Services.Interfaces;
using Api.UseCases.Generic.Requests;
using Microsoft.AspNetCore.Mvc;
using Quiplogs.Schedules.Data.Entities;
using Quiplogs.Schedules.Domain.Entities;
using System.Threading.Tasks;
using Api.Presenters;
using Quiplogs.Schedules.UseCases.ScheduleYearly;

namespace Api.UseCases.Schedule.Yearly.Put
{
    public class ScheduleYearlyController : BaseApiController
    {
        private readonly PutScheduleYearlyUseCase _putUseCase;
        private readonly PutPresenter<ScheduleYearly> _putPresenter;

        public ScheduleYearlyController(PutScheduleYearlyUseCase putUseCase, PutPresenter<ScheduleYearly> putPresenter)
        {
            _putUseCase = putUseCase;
            _putPresenter = putPresenter;
        }

        [HttpPut()]
        public async Task<ActionResult> Put([FromBody] PutRequest<ScheduleYearly> request)
        {
            if (!ModelState.IsValid)
            {
                // re-render the view when validation failed.
                return BadRequest(ModelState);
            }

            if (request.Model.DateNextDue == null)
                request.Model.DateNextDue = DateTime.Now;

            await _putUseCase.Handle(new Quiplogs.Core.Dto.Requests.Generic.PutRequest<ScheduleYearly>(request.Model), _putPresenter);
            return _putPresenter.ContentResult;
        }
    }
}
