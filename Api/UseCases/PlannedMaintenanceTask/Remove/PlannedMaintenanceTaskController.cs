using Api.Services.Interfaces;
using Api.UseCases.Generic.Requests;
using Microsoft.AspNetCore.Mvc;
using Quiplogs.PlannedMaintenance.Data.Entities;
using System.Threading.Tasks;

namespace Api.UseCases.PlannedMaintenanceTask.Remove
{
    public class PlannedMaintenanceTaskController : BaseApiController
    {
        private readonly IRemoveService<Quiplogs.PlannedMaintenance.Domain.Entities.PlannedMaintenanceTask, PlannedMaintenanceTaskDto> _removeService;

        public PlannedMaintenanceTaskController(IRemoveService<Quiplogs.PlannedMaintenance.Domain.Entities.PlannedMaintenanceTask, PlannedMaintenanceTaskDto> removeService)
        {
            _removeService = removeService;
        }

        [HttpDelete()]
        public async Task<ActionResult> Delete([FromBody] RemoveRequest request)
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