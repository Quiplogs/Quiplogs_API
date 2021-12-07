using Api.Presenters;
using Api.UseCases.Generic.Requests;
using Microsoft.AspNetCore.Mvc;
using Quiplogs.PlannedMaintenance.UseCases.PlannedMaintenancePart;
using System.Threading.Tasks;

namespace Api.UseCases.PlannedMaintenancePart.Put
{
    public class PlannedMaintenancePartController : BaseApiController
    {
        private readonly PutPlannedMaintenancePartUseCase _putUseCase;
        private readonly PutPresenter<Quiplogs.PlannedMaintenance.Domain.Entities.PlannedMaintenancePart> _putPresenter;

        public PlannedMaintenancePartController(PutPlannedMaintenancePartUseCase putUseCase, PutPresenter<Quiplogs.PlannedMaintenance.Domain.Entities.PlannedMaintenancePart> putPresenter)
        {
            _putUseCase = putUseCase;
            _putPresenter = putPresenter;
        }

        [HttpPut()]
        public async Task<ActionResult> Put([FromBody] PutRequest<Quiplogs.PlannedMaintenance.Domain.Entities.PlannedMaintenancePart> request)
        {
            if (!ModelState.IsValid)
            {
                // re-render the view when validation failed.
                return BadRequest(ModelState);
            }

            request.Model.CompanyId = GetCompanyId(request.Model.CompanyId);

            await _putUseCase.Handle(new Quiplogs.Core.Dto.Requests.Generic.PutRequest<Quiplogs.PlannedMaintenance.Domain.Entities.PlannedMaintenancePart>(request.Model), _putPresenter);
            return _putPresenter.ContentResult;
        }
    }
}