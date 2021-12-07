using Api.Presenters;
using Microsoft.AspNetCore.Mvc;
using Quiplogs.Core.Dto.Requests.Generic;
using Quiplogs.Schedules.Domain.Entities;
using Quiplogs.Schedules.UseCases.ScheduleMonthly;
using System.Threading.Tasks;

namespace Api.UseCases.Schedule.Monthly.List
{
    public class ScheduleMonthlyController : BaseApiController
    {
        private readonly ListScheduleMonthlyUseCase _listUseCase;
        private readonly ListPresenter<ScheduleMonthly> _listPresenter;

        public ScheduleMonthlyController(ListScheduleMonthlyUseCase listUseCase, ListPresenter<ScheduleMonthly> listPresenter)
        {
            _listUseCase = listUseCase;
            _listPresenter = listPresenter;
        }

        [HttpPost("ListByParent")]
        public async Task<ActionResult> List([FromBody] ListRequest<ScheduleMonthly> request)
        {
            if (!ModelState.IsValid)
            {
                // re-render the view when validation failed.
                return BadRequest(ModelState);
            }

            await _listUseCase.Handle(new ListRequest<ScheduleMonthly>(GetCompanyId(request.CompanyId), request.LocationId, request.ParentId, request.FilterParameters), _listPresenter);
            return _listPresenter.ContentResult;
        }
    }
}
