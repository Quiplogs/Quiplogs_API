using Api.Services.Interfaces;
using Api.UseCases.Generic.Requests;
using Microsoft.AspNetCore.Mvc;
using Quiplogs.Inventory.Data.Entities;
using Quiplogs.Inventory.Domain.Entities;
using System.Threading.Tasks;

namespace Api.UseCases.Task.Put
{
    public class TaskController : BaseApiController
    {
        private readonly IPutService<TaskEntity, TaskDto> _putService;

        public TaskController(IPutService<TaskEntity, TaskDto> putService)
        {
            _putService = putService;
        }

        [HttpPut()]
        public async Task<ActionResult> Put([FromBody] PutRequest<TaskEntity> request)
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