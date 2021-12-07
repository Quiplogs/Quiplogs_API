using Api.Presenters;
using Api.UseCases.Generic.Requests;
using Microsoft.AspNetCore.Mvc;
using Quiplogs.Schedules.Domain.Entities;
using Quiplogs.Schedules.UseCases.ScheduleDaily;
using System;
using System.Threading.Tasks;

namespace Api.UseCases.Schedule.Daily.Put
{
    public class ScheduleDailyController : BaseApiController
    {
        private readonly PutScheduleDailyUseCase _putUseCase;
        private readonly PutPresenter<ScheduleDaily> _putPresenter;

        public ScheduleDailyController(PutScheduleDailyUseCase putUseCase, PutPresenter<ScheduleDaily> putPresenter)
        {
            _putUseCase = putUseCase;
            _putPresenter = putPresenter;
        }

        [HttpPut()]
        public async Task<ActionResult> Put([FromBody] PutRequest<ScheduleDaily> request)
        {
            if (!ModelState.IsValid)
            {
                // re-render the view when validation failed.
                return BadRequest(ModelState);
            }

            request.Model.DateNextDue ??= DateTime.Now;
            request.Model.CompanyId = GetCompanyId(request.Model.CompanyId);

            await _putUseCase.Handle(new Quiplogs.Core.Dto.Requests.Generic.PutRequest<ScheduleDaily>(request.Model), _putPresenter);
            return _putPresenter.ContentResult;
        }
    }
}
