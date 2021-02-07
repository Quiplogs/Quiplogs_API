using Api.Services.Interfaces;
using Api.UseCases.Generic.Requests;
using Microsoft.AspNetCore.Mvc;
using Quiplogs.PlannedMaintenance.Data.Entities;
using System.Threading.Tasks;

namespace Api.UseCases.PlannedMaintenance.Put
{
    public class PlannedMaintenanceController : BaseApiController
    {
        private readonly IPutService<Quiplogs.PlannedMaintenance.Domain.Entities.PlannedMaintenance, PlannedMaintenanceDto> _putService;

        public PlannedMaintenanceController(IPutService<Quiplogs.PlannedMaintenance.Domain.Entities.PlannedMaintenance, PlannedMaintenanceDto> putService)
        {
            _putService = putService;
        }

        [HttpPut()]
        public async Task<ActionResult> Put([FromBody] PutRequest<Quiplogs.PlannedMaintenance.Domain.Entities.PlannedMaintenance> request)
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