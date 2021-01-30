using Api.Services.Interfaces;
using Api.UseCases.Generic.Requests;
using Microsoft.AspNetCore.Mvc;
using Quiplogs.WorkOrder.Data.Entities;
using Quiplogs.WorkOrder.Domain.Entities;
using System.Threading.Tasks;

namespace Api.UseCases.WorkOrder.Get
{
    public class WorkOrderController : BaseApiController
    {
        private readonly IGetService<WorkOrderEntity, WorkOrderDto> _getService;

        public WorkOrderController(IGetService<WorkOrderEntity, WorkOrderDto> getService)
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