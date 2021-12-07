using Api.Presenters;
using Api.UseCases.Generic.Requests;
using Microsoft.AspNetCore.Mvc;
using Quiplogs.Schedules.Domain.Entities;
using Quiplogs.Schedules.UseCases.ScheduleYearly;
using System;
using System.Threading.Tasks;

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

            request.Model.DateNextDue ??= DateTime.Now;
            request.Model.CompanyId = GetCompanyId(request.Model.CompanyId);

            await _putUseCase.Handle(new Quiplogs.Core.Dto.Requests.Generic.PutRequest<ScheduleYearly>(request.Model), _putPresenter);
            return _putPresenter.ContentResult;
        }
    }
}
