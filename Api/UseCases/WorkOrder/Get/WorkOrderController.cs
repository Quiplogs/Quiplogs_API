using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Quiplogs.WorkOrder.Interfaces.UseCases.WorkOrder;

namespace Api.UseCases.WorkOrder.Get
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    //[Authorize]
    [ApiController]
    public class WorkOrderController : ControllerBase
    {
        private readonly IGetWorkOrderUseCase _getWorkOrderUseCase;
        private readonly GetWorkOrderPresenter _getWorkOrderPresenter;

        public WorkOrderController(IGetWorkOrderUseCase getWorkOrderUseCase, GetWorkOrderPresenter getWorkOrderPresenter)
        {
            _getWorkOrderUseCase = getWorkOrderUseCase;
            _getWorkOrderPresenter = getWorkOrderPresenter;
        }


        [HttpGet("Get")]
        public async Task<ActionResult> Get([FromQuery] GetWorkOrderRequest request)
        {
            if (!ModelState.IsValid)
            { // re-render the view when validation failed.
                return BadRequest(ModelState);
            }
            await _getWorkOrderUseCase.Handle(new Quiplogs.WorkOrder.Dto.Requests.WorkOrder.GetWorkOrderRequest(request.Id), _getWorkOrderPresenter);
            return _getWorkOrderPresenter.ContentResult;
        }
    }
}