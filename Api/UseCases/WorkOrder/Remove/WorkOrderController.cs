using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Quiplogs.WorkOrder.Interfaces.UseCases.WorkOrder;

namespace Api.UseCases.WorkOrder.Remove
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    //[Authorize]
    [ApiController]
    public class WorkOrderController : ControllerBase
    {
        private readonly IRemoveWorkOrderUseCase _removeWorkOrderUseCase;
        private readonly RemoveWorkOrderPresenter _removeWorkOrderPresenter;

        public WorkOrderController(IRemoveWorkOrderUseCase removeWorkOrderUseCase, RemoveWorkOrderPresenter removeWorkOrderPresenter)
        {
            _removeWorkOrderUseCase = removeWorkOrderUseCase;
            _removeWorkOrderPresenter = removeWorkOrderPresenter;
        }

        [HttpPost("Remove")]
        public async Task<ActionResult> Remove([FromBody] RemoveWorkOrderRequest request)
        {
            if (!ModelState.IsValid)
            { // re-render the view when validation failed.
                return BadRequest(ModelState);
            }
            await _removeWorkOrderUseCase.Handle(new Quiplogs.WorkOrder.Dto.Requests.WorkOrder.RemoveWorkOrderRequest(request.Id), _removeWorkOrderPresenter);
            return _removeWorkOrderPresenter.ContentResult;
        }
    }
}