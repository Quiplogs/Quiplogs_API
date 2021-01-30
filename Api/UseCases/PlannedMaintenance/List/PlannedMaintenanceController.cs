using System.Threading.Tasks;
using Api.Services.Interfaces;
using Api.UseCases.Generic.Requests;
using Microsoft.AspNetCore.Mvc;
using Quiplogs.WorkOrder.Data.Entities;

namespace Api.UseCases.PlannedMaintenance.List
{
    public class PlannedMaintenanceController : BaseApiController
    {
        private readonly IPagedListService<Quiplogs.WorkOrder.Domain.Entities.PlannedMaintenance, PlannedMaintenanceDto> _pagedService;

        public PlannedMaintenanceController(IPagedListService<Quiplogs.WorkOrder.Domain.Entities.PlannedMaintenance, PlannedMaintenanceDto> pagedService)
        {
            _pagedService = pagedService;
        }

        [HttpPost("PagedList")]
        public async Task<ActionResult> PagedList([FromBody] PagedListRequest<Quiplogs.WorkOrder.Domain.Entities.PlannedMaintenance> request)
        {
            if (!ModelState.IsValid)
            {
                // re-render the view when validation failed.
                return BadRequest(ModelState);
            }

            var result = await _pagedService.PagedList(request);
            return result;
        }
    }
}