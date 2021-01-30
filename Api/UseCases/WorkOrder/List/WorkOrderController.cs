using System.Threading.Tasks;
using Api.Services.Interfaces;
using Api.UseCases.Generic.Requests;
using Microsoft.AspNetCore.Mvc;
using Quiplogs.WorkOrder.Data.Entities;

namespace Api.UseCases.WorkOrder.List
{
    public class WorkOrderController : BaseApiController
    {
        private readonly IPagedListService<Quiplogs.WorkOrder.Domain.Entities.WorkOrderEntity, WorkOrderDto> _pagedService;

        public WorkOrderController(IPagedListService<Quiplogs.WorkOrder.Domain.Entities.WorkOrderEntity, WorkOrderDto> pagedService)
        {
            _pagedService = pagedService;
        }

        [HttpPost("PagedList")]
        public async Task<ActionResult> PagedList([FromBody] PagedListRequest<Quiplogs.WorkOrder.Domain.Entities.WorkOrderEntity> request)
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