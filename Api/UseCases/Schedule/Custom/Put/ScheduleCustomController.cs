using Api.Presenters;
using Api.UseCases.Generic.Requests;
using Microsoft.AspNetCore.Mvc;
using Quiplogs.Schedules.Domain.Entities;
using Quiplogs.Schedules.UseCases.ScheduleCustom;
using System.Threading.Tasks;

namespace Api.UseCases.Schedule.Custom.Put
{
    public class ScheduleCustomController : BaseApiController
    {
        private readonly PutScheduleCustomUseCase _putUseCase;
        private readonly PutPresenter<ScheduleCustom> _putPresenter;

        public ScheduleCustomController(PutScheduleCustomUseCase putUseCase, PutPresenter<ScheduleCustom> putPresenter)
        {
            _putUseCase = putUseCase;
            _putPresenter = putPresenter;
        }


        [HttpPut()]
        public async Task<ActionResult> Put([FromBody] PutRequest<ScheduleCustom> request)
        {
            if (!ModelState.IsValid)
            {
                // re-render the view when validation failed.
                return BadRequest(ModelState);
            }

            request.Model.CycleNextDue ??= 0;
            request.Model.CompanyId = GetCompanyId(request.Model.CompanyId);

            await _putUseCase.Handle(new Quiplogs.Core.Dto.Requests.Generic.PutRequest<ScheduleCustom>(request.Model), _putPresenter);
            return _putPresenter.ContentResult;
        }
    }
}
