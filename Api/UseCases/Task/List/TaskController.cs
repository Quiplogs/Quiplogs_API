using Api.Services.Interfaces;
using Api.UseCases.Generic.Requests;
using Microsoft.AspNetCore.Mvc;
using Quiplogs.Inventory.Data.Entities;
using System.Threading.Tasks;

namespace Api.UseCases.Task.List
{
    public class TaskController : BaseApiController
    {
        private readonly IPagedListService<Quiplogs.Inventory.Domain.Entities.TaskEntity, TaskDto> _pagedService;

        public TaskController(IPagedListService<Quiplogs.Inventory.Domain.Entities.TaskEntity, TaskDto> pagedService)
        {
            _pagedService = pagedService;
        }

        [HttpPost("PagedList")]
        public async Task<ActionResult> PagedList([FromBody] PagedListRequest<Quiplogs.Inventory.Domain.Entities.TaskEntity> request)
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