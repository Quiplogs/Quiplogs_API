using Api.Services.Interfaces;
using Api.UseCases.Generic.Requests;
using Microsoft.AspNetCore.Mvc;
using Quiplogs.WorkOrder.Data.Entities;
using System.Threading.Tasks;

namespace Api.UseCases.PlannedMaintenanceTask.Put
{
    public class PlannedMaintenanceTaskController : BaseApiController
    {
        private readonly IPutService<Quiplogs.WorkOrder.Domain.Entities.PlannedMaintenanceTask, PlannedMaintenanceTaskDto> _putService;

        public PlannedMaintenanceTaskController(IPutService<Quiplogs.WorkOrder.Domain.Entities.PlannedMaintenanceTask, PlannedMaintenanceTaskDto> putService)
        {
            _putService = putService;
        }

        [HttpPut()]
        public async Task<ActionResult> Put([FromBody] PutRequest<Quiplogs.WorkOrder.Domain.Entities.PlannedMaintenanceTask> request)
        {
            if (!ModelState.IsValid)
            {
                // re-render the view when validation failed.
                return BadRequest(ModelState);
            }

            var result = await _putService.Put(request);
            return result;
        }
    }
}