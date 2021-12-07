using Api.Presenters;
using Microsoft.AspNetCore.Mvc;
using Quiplogs.Core.Dto.Requests.Generic;
using Quiplogs.PlannedMaintenance.UseCases.PlannedMaintenancePart;
using System.Threading.Tasks;

namespace Api.UseCases.PlannedMaintenancePart.List
{
    public class PlannedMaintenancePartController : BaseApiController
    {
        private readonly ListPlannedMaintenancePartUseCase _listUseCase;
        private readonly ListPresenter<Quiplogs.PlannedMaintenance.Domain.Entities.PlannedMaintenancePart> _listPresenter;

        public PlannedMaintenancePartController(ListPlannedMaintenancePartUseCase listUseCase, ListPresenter<Quiplogs.PlannedMaintenance.Domain.Entities.PlannedMaintenancePart> listPresenter)
        {
            _listUseCase = listUseCase;
            _listPresenter = listPresenter;
        }

        [HttpPost("ListByParent")]
        public async Task<ActionResult> List([FromBody] ListRequest<Quiplogs.PlannedMaintenance.Domain.Entities.PlannedMaintenancePart> request)
        {
            if (!ModelState.IsValid)
            {
                // re-render the view when validation failed.
                return BadRequest(ModelState);
            }

            await _listUseCase.Handle(new ListRequest<Quiplogs.PlannedMaintenance.Domain.Entities.PlannedMaintenancePart>(GetCompanyId(request.CompanyId), request.LocationId, request.ParentId, request.FilterParameters), _listPresenter);
            return _listPresenter.ContentResult;
        }
    }
}