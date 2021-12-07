using Api.Services.Interfaces;
using Api.UseCases.Generic.Requests;
using Microsoft.AspNetCore.Mvc;
using Quiplogs.PlannedMaintenance.Data.Entities;
using System.Threading.Tasks;

namespace Api.UseCases.PlannedMaintenancePart.Remove
{
    public class PlannedMaintenancePartController : BaseApiController
    {
        private readonly IRemoveService<Quiplogs.PlannedMaintenance.Domain.Entities.PlannedMaintenancePart, PlannedMaintenancePartDto> _removeService;

        public PlannedMaintenancePartController(IRemoveService<Quiplogs.PlannedMaintenance.Domain.Entities.PlannedMaintenancePart, PlannedMaintenancePartDto> removeService)
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