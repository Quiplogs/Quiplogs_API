using Api.Services.Interfaces;
using Api.UseCases.Generic.Requests;
using Microsoft.AspNetCore.Mvc;
using Quiplogs.Inventory.Data.Entities;
using Quiplogs.Inventory.Domain.Entities;
using System.Threading.Tasks;

namespace Api.UseCases.Task.Remove
{
    public class TaskController : BaseApiController
    {
        private readonly IRemoveService<TaskEntity, TaskDto> _removeService;

        public TaskController(IRemoveService<TaskEntity, TaskDto> removeService)
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