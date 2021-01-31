using Api.Services.Interfaces;
using Api.UseCases.Generic.Requests;
using Microsoft.AspNetCore.Mvc;
using Quiplogs.PlannedMaintenance.Data.Entities;
using System.Threading.Tasks;

namespace Api.UseCases.PlannedMaintenance.Get
{
    public class PlannedMaintenanceController : BaseApiController
    {
        private readonly IGetService<Quiplogs.PlannedMaintenance.Domain.Entities.PlannedMaintenance, PlannedMaintenanceDto> _getService;

        public PlannedMaintenanceController(IGetService<Quiplogs.PlannedMaintenance.Domain.Entities.PlannedMaintenance, PlannedMaintenanceDto> getService)
        {
            _getService = getService;
        }

        [HttpGet()]
        public async Task<ActionResult> Get([FromQuery] GetRequest request)
        {
            if (!ModelState.IsValid)
            {
                // re-render the view when validation failed.
                return BadRequest(ModelState);
            }

            var result = await _getService.Get(request);
            return result;
        }
    }
}