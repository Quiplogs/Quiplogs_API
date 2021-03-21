using Api.Presenters;
using Api.UseCases.Generic.Requests;
using Microsoft.AspNetCore.Mvc;
using Quiplogs.Schedules.Domain.Entities;
using Quiplogs.Schedules.UseCases.ScheduleWeekly;
using System;
using System.Threading.Tasks;

namespace Api.UseCases.Schedule.Weekly.Put
{
    public class ScheduleWeeklyController : BaseApiController
    {
        private readonly PutScheduleWeeklyUseCase _putUseCase;
        private readonly PutPresenter<ScheduleWeekly> _putPresenter;

        public ScheduleWeeklyController(PutScheduleWeeklyUseCase putUseCase, PutPresenter<ScheduleWeekly> putPresenter)
        {
            _putUseCase = putUseCase;
            _putPresenter = putPresenter;
        }

        [HttpPut()]
        public async Task<ActionResult> Put([FromBody] PutRequest<ScheduleWeekly> request)
        {
            if (!ModelState.IsValid)
            {
                // re-render the view when validation failed.
                return BadRequest(ModelState);
            }

            if (request.Model.DateNextDue == null)
                request.Model.DateNextDue = DateTime.Now;

            await _putUseCase.Handle(new Quiplogs.Core.Dto.Requests.Generic.PutRequest<ScheduleWeekly>(request.Model), _putPresenter);
            return _putPresenter.ContentResult;
        }
    }
}
