using Api.Services.Interfaces;
using Api.UseCases.Generic.Requests;
using Microsoft.AspNetCore.Mvc;
using Quiplogs.PlannedMaintenance.Data.Entities;
using System.Threading.Tasks;

namespace Api.UseCases.PlannedMaintenance.Remove
{
    public class PlannedMaintenanceController : BaseApiController
    {
        private readonly IRemoveService<Quiplogs.PlannedMaintenance.Domain.Entities.PlannedMaintenance, PlannedMaintenanceDto> _removeService;

        public PlannedMaintenanceController(IRemoveService<Quiplogs.PlannedMaintenance.Domain.Entities.PlannedMaintenance, PlannedMaintenanceDto> removeService)
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