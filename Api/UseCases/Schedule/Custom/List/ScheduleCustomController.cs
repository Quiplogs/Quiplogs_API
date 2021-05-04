using Api.Presenters;
using Microsoft.AspNetCore.Mvc;
using Quiplogs.Core.Dto.Requests.Generic;
using Quiplogs.Schedules.Domain.Entities;
using Quiplogs.Schedules.UseCases.ScheduleCustom;
using System.Threading.Tasks;

namespace Api.UseCases.Schedule.Custom.List
{
    public class ScheduleCustomController : BaseApiController
    {
        private readonly ListScheduleCustomUseCase _listUseCase;
        private readonly ListPresenter<ScheduleCustom> _listPresenter;

        public ScheduleCustomController(ListScheduleCustomUseCase listUseCase, ListPresenter<ScheduleCustom> listPresenter)
        {
            _listUseCase = listUseCase;
            _listPresenter = listPresenter;
        }

        [HttpPost("ListByParent")]
        public async Task<ActionResult> List([FromBody] ListRequest<ScheduleCustom> request)
        {
            if (!ModelState.IsValid)
            {
                // re-render the view when validation failed.
                return BadRequest(ModelState);
            }

            await _listUseCase.Handle(new ListRequest<ScheduleCustom>(GetCompanyId(request.CompanyId), request.LocationId, request.ParentId, request.FilterParameters), _listPresenter);
            return _listPresenter.ContentResult;
        }
    }
}
