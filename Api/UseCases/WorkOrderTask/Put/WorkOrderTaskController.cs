using Api.Services.Interfaces;
using Api.UseCases.Generic.Requests;
using Microsoft.AspNetCore.Mvc;
using Quiplogs.WorkOrder.Data.Entities;
using System.Threading.Tasks;

namespace Api.UseCases.WorkOrderTask.Put
{
    public class WorkOrderTaskController : BaseApiController
    {
        private readonly IPutService<Quiplogs.WorkOrder.Domain.Entities.WorkOrderTask, WorkOrderTaskDto> _putService;

        public WorkOrderTaskController(IPutService<Quiplogs.WorkOrder.Domain.Entities.WorkOrderTask, WorkOrderTaskDto> putService)
        {
            _putService = putService;
        }

        [HttpPut()]
        public async Task<ActionResult> Put([FromBody] PutRequest<Quiplogs.WorkOrder.Domain.Entities.WorkOrderTask> request)
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