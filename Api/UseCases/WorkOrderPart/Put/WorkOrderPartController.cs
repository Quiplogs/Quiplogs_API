using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Quiplogs.WorkOrder.Interfaces.UseCases.WorkOrderPart;

namespace Api.UseCases.WorkOrderPart.Put
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    //[Authorize]
    [ApiController]
    public class WorkOrderPartController : ControllerBase
    {
        private readonly IPutWorkOrderPartUseCase _putWorkOrderPartUseCase;
        private readonly PutWorkOrderPartPresenter _putWorkOrderPartPresenter;

        public WorkOrderPartController(IPutWorkOrderPartUseCase putWorkOrderPartUseCase, PutWorkOrderPartPresenter putWorkOrderPartPresenter)
        {
            _putWorkOrderPartUseCase = putWorkOrderPartUseCase;
            _putWorkOrderPartPresenter = putWorkOrderPartPresenter;
        }

        [HttpPut("Put")]
        public async Task<ActionResult> Put([FromBody] PutWorkOrderPartRequest request)
        {
            if (!ModelState.IsValid)
            { // re-render the view when validation failed.
                return BadRequest(ModelState);
            }
            await _putWorkOrderPartUseCase.Handle(new Quiplogs.WorkOrder.Dto.Requests.WorkOrderPart.PutWorkOrderPartRequest(request.WorkOrderPart), _putWorkOrderPartPresenter);
            return _putWorkOrderPartPresenter.ContentResult;
        }
    }
}