using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Quiplogs.WorkOrder.Interfaces.UseCases.PlannedMaintenanceTask;

namespace Api.UseCases.PlannedMaintenanceTask.Put
{
    public class PlannedMaintenanceTaskController : BaseApiController
    {
        private readonly IPutPlannedMaintenanceTaskUseCase _putPlannedMaintenanceTaskUseCase;
        private readonly PutPlannedMaintenanceTaskPresenter _putPlannedMaintenanceTaskPresenter;

        public PlannedMaintenanceTaskController(IPutPlannedMaintenanceTaskUseCase putPlannedMaintenanceTaskUseCase, PutPlannedMaintenanceTaskPresenter putPlannedMaintenanceTaskPresenter)
        {
            _putPlannedMaintenanceTaskUseCase = putPlannedMaintenanceTaskUseCase;
            _putPlannedMaintenanceTaskPresenter = putPlannedMaintenanceTaskPresenter;
        }

        [HttpPut()]
        public async Task<ActionResult> Put([FromBody] PutPlannedMaintenanceTaskRequest request)
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

            await _putPlannedMaintenanceTaskUseCase.Handle(new Quiplogs.WorkOrder.Dto.Requests.PlannedMaintenanceTask.PutPlannedMaintenanceTaskRequest(companyId, request.PlannedMaintenanceId, request.TaskId, request.Quantity), _putPlannedMaintenanceTaskPresenter);
            return _putPlannedMaintenanceTaskPresenter.ContentResult;
        }
    }
}