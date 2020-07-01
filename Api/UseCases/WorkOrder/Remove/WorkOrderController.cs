using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Quiplogs.WorkOrder.Interfaces.UseCases.WorkOrder;

namespace Api.UseCases.WorkOrder.Remove
{
    public class WorkOrderController : BaseApiController
    {
        private readonly IRemoveWorkOrderUseCase _removeWorkOrderUseCase;
        private readonly RemoveWorkOrderPresenter _removeWorkOrderPresenter;

        public WorkOrderController(IRemoveWorkOrderUseCase removeWorkOrderUseCase, RemoveWorkOrderPresenter removeWorkOrderPresenter)
        {
            _removeWorkOrderUseCase = removeWorkOrderUseCase;
            _removeWorkOrderPresenter = removeWorkOrderPresenter;
        }

        [HttpDelete()]
        public async Task<ActionResult> Remove([FromQuery] RemoveWorkOrderRequest request)
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