using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Quiplogs.WorkOrder.Interfaces.UseCases.WorkOrder;

namespace Api.UseCases.WorkOrder.List
{
    public class WorkOrderController : BaseApiController
    {
        private readonly IListWorkOrderUseCase _listWorkOrderUseCase;
        private readonly ListWorkOrderPresenter _listWorkOrderPresenter;

        public WorkOrderController(IListWorkOrderUseCase listWorkOrderUseCase, ListWorkOrderPresenter listWorkOrderPresenter)
        {
            _listWorkOrderUseCase = listWorkOrderUseCase;
            _listWorkOrderPresenter = listWorkOrderPresenter;
        }

        [HttpGet("List")]
        public async Task<ActionResult> List([FromQuery] ListWorkOrderRequest request)
        {
            if (!ModelState.IsValid)
            { // re-render the view when validation failed.
                return BadRequest(ModelState);
            }

            var companyId = request.CompanyId;
            if (string.IsNullOrEmpty(companyId))
            {
                companyId = this.GetCompanyId();
            }

            await _listWorkOrderUseCase.Handle(new Quiplogs.WorkOrder.Dto.Requests.WorkOrder.ListWorkOrderRequest(companyId, request.LocationId, request.AssetId, request.PageNumber), _listWorkOrderPresenter);
            return _listWorkOrderPresenter.ContentResult;
        }
    }
}