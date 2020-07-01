using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Quiplogs.WorkOrder.Interfaces.UseCases.WorkOrderPart;

namespace Api.UseCases.WorkOrderPart.List
{
    public class WorkOrderPartController : BaseApiController
    {
        private readonly IListWorkOrderPartUseCase _listWorkOrderPartUseCase;
        private readonly ListWorkOrderPartPresenter _listWorkOrderPartPresenter;

        public WorkOrderPartController(IListWorkOrderPartUseCase listWorkOrderPartUseCase, ListWorkOrderPartPresenter listWorkOrderPartPresenter)
        {
            _listWorkOrderPartUseCase = listWorkOrderPartUseCase;
            _listWorkOrderPartPresenter = listWorkOrderPartPresenter;
        }

        [HttpGet("List")]
        public async Task<ActionResult> List([FromQuery] ListWorkOrderPartRequest request)
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

            await _listWorkOrderPartUseCase.Handle(new Quiplogs.WorkOrder.Dto.Requests.WorkOrderPart.ListWorkOrderPartRequest(request.WordOrderId, request.PageNumber), _listWorkOrderPartPresenter);
            return _listWorkOrderPartPresenter.ContentResult;
        }
    }
}