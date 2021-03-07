using Api.Presenters;
using Microsoft.AspNetCore.Mvc;
using Quiplogs.Core.Dto.Requests.Generic;
using Quiplogs.Schedules.Domain.Entities;
using Quiplogs.Schedules.UseCases.ScheduleWeekly;
using System.Threading.Tasks;

namespace Api.UseCases.Schedule.Weekly.List
{
    public class ScheduleWeeklyController : BaseApiController
    {
        private readonly ListScheduleWeeklyUseCase _listUseCase;
        private readonly ListPresenter<ScheduleWeekly> _listPresenter;

        public ScheduleWeeklyController(ListScheduleWeeklyUseCase listUseCase, ListPresenter<ScheduleWeekly> listPresenter)
        {
            _listUseCase = listUseCase;
            _listPresenter = listPresenter;
        }

        [HttpPost("ListByParent")]
        public async Task<ActionResult> List([FromBody] ListRequest<ScheduleWeekly> request)
        {
            if (!ModelState.IsValid)
            {
                // re-render the view when validation failed.
                return BadRequest(ModelState);
            }

            await _listUseCase.Handle(new ListRequest<ScheduleWeekly>(request.CompanyId, request.LocationId, request.ParentId, request.FilterParameters), _listPresenter);
            return _listPresenter.ContentResult;
        }
    }
}
