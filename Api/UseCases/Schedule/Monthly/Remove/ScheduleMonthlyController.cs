using Api.Services.Interfaces;
using Api.UseCases.Generic.Requests;
using Microsoft.AspNetCore.Mvc;
using Quiplogs.Schedules.Data.Entities;
using Quiplogs.Schedules.Domain.Entities;
using System.Threading.Tasks;

namespace Api.UseCases.Schedule.Monthly.Remove
{
    public class ScheduleMonthlyController : BaseApiController
    {
        private readonly IRemoveService<ScheduleMonthly, ScheduleMonthlyDto> _removeService;

        public ScheduleMonthlyController(IRemoveService<ScheduleMonthly, ScheduleMonthlyDto> removeService)
        {
            _removeService = removeService;
        }

        [HttpDelete()]
        public async Task<ActionResult> Delete([FromQuery] RemoveRequest request)
        {
            if (!ModelState.IsValid)
            {
                // re-render the view when validation failed.
                return BadRequest(ModelState);
            }

            var result = await _removeService.Put(request);
            return result;
        }
    }
}
