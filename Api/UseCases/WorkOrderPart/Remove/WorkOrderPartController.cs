using System.Threading.Tasks;
using Api.UseCases.WorkOrderPartPart.Remove;
using Microsoft.AspNetCore.Mvc;
using Quiplogs.WorkOrder.Interfaces.UseCases.WorkOrderPart;

namespace Api.UseCases.WorkOrderPart.Remove
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    //[Authorize]
    [ApiController]
    public class WorkOrderPartController : ControllerBase
    {
        private readonly IRemoveWorkOrderPartUseCase _removeWorkOrderPartUseCase;
        private readonly RemoveWorkOrderPartPresenter _removeWorkOrderPartPresenter;

        public WorkOrderPartController(IRemoveWorkOrderPartUseCase removeWorkOrderPartUseCase, RemoveWorkOrderPartPresenter removeWorkOrderPartPresenter)
        {
            _removeWorkOrderPartUseCase = removeWorkOrderPartUseCase;
            _removeWorkOrderPartPresenter = removeWorkOrderPartPresenter;
        }

        [HttpPost("Remove")]
        public async Task<ActionResult> Remove([FromBody] RemoveWorkOrderPartRequest request)
        {
            if (!ModelState.IsValid)
            { // re-render the view when validation failed.
                return BadRequest(ModelState);
            }
            await _removeWorkOrderPartUseCase.Handle(new Quiplogs.WorkOrder.Dto.Requests.WorkOrderPart.RemoveWorkOrderPartRequest(request.Id), _removeWorkOrderPartPresenter);
            return _removeWorkOrderPartPresenter.ContentResult;
        }
    }
}