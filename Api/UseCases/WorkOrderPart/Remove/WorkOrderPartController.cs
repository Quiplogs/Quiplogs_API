using Api.Services.Interfaces;
using Api.UseCases.Generic.Requests;
using Microsoft.AspNetCore.Mvc;
using Quiplogs.WorkOrder.Data.Entities;
using System.Threading.Tasks;

namespace Api.UseCases.WorkOrderPart.Remove
{
    public class WorkOrderPartController : BaseApiController
    {
        private readonly IRemoveService<Quiplogs.WorkOrder.Domain.Entities.WorkOrderPart, WorkOrderPartDto> _removeService;

        public WorkOrderPartController(IRemoveService<Quiplogs.WorkOrder.Domain.Entities.WorkOrderPart, WorkOrderPartDto> removeService)
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