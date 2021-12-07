using Api.Presenters;
using Microsoft.AspNetCore.Mvc;
using Quiplogs.Core.Dto.Requests.Generic;
using Quiplogs.Schedules.Domain.Entities;
using Quiplogs.Schedules.UseCases.ScheduleDaily;
using System.Threading.Tasks;

namespace Api.UseCases.Schedule.Daily.List
{
    public class ScheduleDailyController : BaseApiController
    {
        private readonly ListScheduleDailyUseCase _listUseCase;
        private readonly ListPresenter<ScheduleDaily> _listPresenter;

        public ScheduleDailyController(ListScheduleDailyUseCase listUseCase, ListPresenter<ScheduleDaily> listPresenter)
        {
            _listUseCase = listUseCase;
            _listPresenter = listPresenter;
        }

        [HttpPost("ListByParent")]
        public async Task<ActionResult> List([FromBody] ListRequest<ScheduleDaily> request)
        {
            if (!ModelState.IsValid)
            {
                // re-render the view when validation failed.
                return BadRequest(ModelState);
            }

            await _listUseCase.Handle(new ListRequest<ScheduleDaily>(GetCompanyId(request.CompanyId), request.LocationId, request.ParentId, request.FilterParameters), _listPresenter);
            return _listPresenter.ContentResult;
        }
    }
}
