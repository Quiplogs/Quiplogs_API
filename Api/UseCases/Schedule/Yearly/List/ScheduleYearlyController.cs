using Api.Presenters;
using Microsoft.AspNetCore.Mvc;
using Quiplogs.Core.Dto.Requests.Generic;
using Quiplogs.Schedules.Domain.Entities;
using Quiplogs.Schedules.UseCases.ScheduleYearly;
using System.Threading.Tasks;

namespace Api.UseCases.Schedule.Yearly.List
{
    public class ScheduleYearlyController : BaseApiController
    {
        private readonly ListScheduleYearlyUseCase _listUseCase;
        private readonly ListPresenter<ScheduleYearly> _listPresenter;

        public ScheduleYearlyController(ListScheduleYearlyUseCase listUseCase, ListPresenter<ScheduleYearly> listPresenter)
        {
            _listUseCase = listUseCase;
            _listPresenter = listPresenter;
        }

        [HttpPost("ListByParent")]
        public async Task<ActionResult> List([FromBody] ListRequest<ScheduleYearly> request)
        {
            if (!ModelState.IsValid)
            {
                // re-render the view when validation failed.
                return BadRequest(ModelState);
            }

            await _listUseCase.Handle(new ListRequest<ScheduleYearly>(request.CompanyId, request.LocationId, request.ParentId, request.FilterParameters), _listPresenter);
            return _listPresenter.ContentResult;
        }
    }
}
