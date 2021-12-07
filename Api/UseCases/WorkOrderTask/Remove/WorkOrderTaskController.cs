using Api.Services.Interfaces;
using Api.UseCases.Generic.Requests;
using Microsoft.AspNetCore.Mvc;
using Quiplogs.WorkOrder.Data.Entities;
using System.Threading.Tasks;

namespace Api.UseCases.WorkOrderTask.Remove
{
    public class WorkOrderTaskController : BaseApiController
    {
        private readonly IRemoveService<Quiplogs.WorkOrder.Domain.Entities.WorkOrderTask, WorkOrderTaskDto> _removeService;

        public WorkOrderTaskController(IRemoveService<Quiplogs.WorkOrder.Domain.Entities.WorkOrderTask, WorkOrderTaskDto> removeService)
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