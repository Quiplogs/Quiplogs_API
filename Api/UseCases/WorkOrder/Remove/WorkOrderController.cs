using Api.Services.Interfaces;
using Api.UseCases.Generic.Requests;
using Microsoft.AspNetCore.Mvc;
using Quiplogs.WorkOrder.Data.Entities;
using Quiplogs.WorkOrder.Domain.Entities;
using System.Threading.Tasks;

namespace Api.UseCases.WorkOrder.Remove
{
    public class WorkOrderController : BaseApiController
    {
        private readonly IRemoveService<WorkOrderEntity, WorkOrderDto> _removeService;

        public WorkOrderController(IRemoveService<WorkOrderEntity, WorkOrderDto> removeService)
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