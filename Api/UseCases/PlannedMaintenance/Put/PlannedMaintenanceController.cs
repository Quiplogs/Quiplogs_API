using Api.Presenters;
using Api.UseCases.Generic.Requests;
using Microsoft.AspNetCore.Mvc;
using Quiplogs.PlannedMaintenance.UseCases.PlannedMaintenance;
using System.Threading.Tasks;

namespace Api.UseCases.PlannedMaintenance.Put
{
    public class PlannedMaintenanceController : BaseApiController
    {
        private readonly PutPlannedMaintenanceUseCase _putUseCase;
        private readonly PutPresenter<Quiplogs.PlannedMaintenance.Domain.Entities.PlannedMaintenance> _putPresenter;

        public PlannedMaintenanceController(PutPlannedMaintenanceUseCase putUseCase, PutPresenter<Quiplogs.PlannedMaintenance.Domain.Entities.PlannedMaintenance> putPresenter)
        {
            _putUseCase = putUseCase;
            _putPresenter = putPresenter;
        }

        [HttpPut]
        public async Task<ActionResult> Put([FromBody] PutRequest<Quiplogs.PlannedMaintenance.Domain.Entities.PlannedMaintenance> request)
        {
            if (!ModelState.IsValid)
            {
                // re-render the view when validation failed.
                return BadRequest(ModelState);
            }

            request.Model.CompanyId = GetCompanyId(request.Model.CompanyId);

            await _putUseCase.Handle(new Quiplogs.Core.Dto.Requests.Generic.PutRequest<Quiplogs.PlannedMaintenance.Domain.Entities.PlannedMaintenance>(request.Model), _putPresenter);
            return _putPresenter.ContentResult;
        }
    }
}