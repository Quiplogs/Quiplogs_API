using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Quiplogs.WorkOrder.Interfaces.UseCases.WorkOrder;

namespace Api.UseCases.WorkOrder.Put
{
    public class WorkOrderController : BaseApiController
    {
        private readonly IPutWorkOrderUseCase _putWorkOrderUseCase;
        private readonly PutWorkOrderPresenter _putWorkOrderPresenter;

        public WorkOrderController(IPutWorkOrderUseCase putWorkOrderUseCase, PutWorkOrderPresenter putWorkOrderPresenter)
        {
            _putWorkOrderUseCase = putWorkOrderUseCase;
            _putWorkOrderPresenter = putWorkOrderPresenter;
        }

        [HttpPut()]
        public async Task<ActionResult> Put([FromBody] PutWorkOrderRequest request)
        {
            if (!ModelState.IsValid)
            { // re-render the view when validation failed.
                return BadRequest(ModelState);
            }

            await _putWorkOrderUseCase.Handle(new Quiplogs.WorkOrder.Dto.Requests.WorkOrder.PutWorkOrderRequest(request.WorkOrder), _putWorkOrderPresenter);
            return _putWorkOrderPresenter.ContentResult;
        }
    }
}