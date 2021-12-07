using Api.Presenters;
using Api.UseCases.Generic.Requests;
using Microsoft.AspNetCore.Mvc;
using Quiplogs.Schedules.Domain.Entities;
using Quiplogs.Schedules.UseCases.ScheduleMonthly;
using System;
using System.Threading.Tasks;

namespace Api.UseCases.Schedule.Monthly.Put
{
    public class ScheduleMonthlyController : BaseApiController
    {
        private readonly PutScheduleMonthlyUseCase _putUseCase;
        private readonly PutPresenter<ScheduleMonthly> _putPresenter;

        public ScheduleMonthlyController(PutScheduleMonthlyUseCase putUseCase, PutPresenter<ScheduleMonthly> putPresenter)
        {
            _putUseCase = putUseCase;
            _putPresenter = putPresenter;
        }

        [HttpPut()]
        public async Task<ActionResult> Put([FromBody] PutRequest<ScheduleMonthly> request)
        {
            if (!ModelState.IsValid)
            {
                // re-render the view when validation failed.
                return BadRequest(ModelState);
            }
            
            request.Model.DateNextDue ??= DateTime.Now;
            request.Model.CompanyId = GetCompanyId(request.Model.CompanyId);

            await _putUseCase.Handle(new Quiplogs.Core.Dto.Requests.Generic.PutRequest<ScheduleMonthly>(request.Model), _putPresenter);
            return _putPresenter.ContentResult;
        }
    }
}
