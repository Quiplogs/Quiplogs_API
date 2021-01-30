using Api.Services.Interfaces;
using Api.UseCases.Generic.Requests;
using Microsoft.AspNetCore.Mvc;
using Quiplogs.WorkOrder.Data.Entities;
using Quiplogs.WorkOrder.Domain.Entities;
using System.Threading.Tasks;

namespace Api.UseCases.WorkOrder.Put
{
    public class WorkOrderController : BaseApiController
    {
        private readonly IPutService<WorkOrderEntity, WorkOrderDto> _putService;

        public WorkOrderController(IPutService<WorkOrderEntity, WorkOrderDto> putService)
        {
            _putService = putService;
        }

        [HttpPut()]
        public async Task<ActionResult> Put([FromBody] PutRequest<WorkOrderEntity> request)
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