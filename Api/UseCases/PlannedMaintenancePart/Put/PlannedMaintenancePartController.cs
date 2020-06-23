using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Quiplogs.WorkOrder.Dto.Requests.PlannedMaintenancePart;
using Quiplogs.WorkOrder.Interfaces.UseCases.PlannedMaintenancePart;

namespace Api.UseCases.PlannedMaintenancePart.Put
{
    public class PlannedMaintenancePartController : BaseApiController
    {
        private readonly IPutPlannedMaintenancePartUseCase _putPlannedMaintenancePartUseCase;
        private readonly PutPlannedMaintenancePartPresenter _putPlannedMaintenancePartPresenter;

        public PlannedMaintenancePartController(IPutPlannedMaintenancePartUseCase putPlannedMaintenancePartUseCase, PutPlannedMaintenancePartPresenter putPlannedMaintenancePartPresenter)
        {
            _putPlannedMaintenancePartUseCase = putPlannedMaintenancePartUseCase;
            _putPlannedMaintenancePartPresenter = putPlannedMaintenancePartPresenter;
        }

        [HttpPut()]
        public async Task<ActionResult> Put([FromBody] PutPlannedMaintenancePartRequest request)
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

            await _putPlannedMaintenancePartUseCase.Handle(new PutPlannedMaintenancePartDtoRequest(companyId, request.PlannedMaintenanceId, request.PartId, request.Quantity, request.UoM), _putPlannedMaintenancePartPresenter);
            return _putPlannedMaintenancePartPresenter.ContentResult;
        }
    }
}