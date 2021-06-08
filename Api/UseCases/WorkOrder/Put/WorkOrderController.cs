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

            request.Model.WorkOrderParts.ForEach(workOrderPart =>
            {
                workOrderPart.CompanyId = GetCompanyId(request.Model.CompanyId);
                workOrderPart.Part = null;
            });
            request.Model.WorkOrderTasks.ForEach(task => task.CompanyId = GetCompanyId(request.Model.CompanyId));

            var result = await _putService.Put(request, GetCompanyId(request.Model.CompanyId));
            return result;
        }
    }
}