using Api.Services.Interfaces;
using Api.UseCases.Generic.Requests;
using Microsoft.AspNetCore.Mvc;
using Quiplogs.Inventory.Data.Entities;
using Quiplogs.Inventory.Domain.Entities;
using System.Threading.Tasks;

namespace Api.UseCases.Task.Get
{
    public class TaskController : BaseApiController
    {
        private readonly IGetService<TaskEntity, TaskDto> _getService;

        public TaskController(IGetService<TaskEntity, TaskDto> getService)
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