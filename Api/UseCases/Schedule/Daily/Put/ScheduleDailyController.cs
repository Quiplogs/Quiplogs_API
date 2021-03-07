using Api.Services.Interfaces;
using Api.UseCases.Generic.Requests;
using Microsoft.AspNetCore.Mvc;
using Quiplogs.Schedules.Data.Entities;
using Quiplogs.Schedules.Domain.Entities;
using System.Threading.Tasks;

namespace Api.UseCases.Schedule.Daily.Put
{
    public class ScheduleDailyController : BaseApiController
    {
        private readonly IPutService<ScheduleDaily, ScheduleDailyDto> _putService;

        public ScheduleDailyController(IPutService<ScheduleDaily, ScheduleDailyDto> putService)
        {
            _putService = putService;
        }

        [HttpPut()]
        public async Task<ActionResult> Put([FromBody] PutRequest<ScheduleDaily> request)
        {
            if (!ModelState.IsValid)
            {
                // re-render the view when validation failed.
                return BadRequest(ModelState);
            }

            var result = await _putService.Put(request, GetCompanyId(request.Model.CompanyId));
            return result;
        }
    }
}
