using Api.Presenters;
using Microsoft.AspNetCore.Mvc;
using Quiplogs.Core.Dto.Requests.Generic;
using Quiplogs.PlannedMaintenance.UseCases.PlannedMaintenanceTask;
using System.Threading.Tasks;

namespace Api.UseCases.PlannedMaintenanceTask.List
{
    public class PlannedMaintenanceTaskController : BaseApiController
    {
        private readonly ListPlannedMaintenanceTaskUseCase _listUseCase;
        private readonly ListPresenter<Quiplogs.PlannedMaintenance.Domain.Entities.PlannedMaintenanceTask> _listPresenter;

        public PlannedMaintenanceTaskController(ListPlannedMaintenanceTaskUseCase listUseCase, ListPresenter<Quiplogs.PlannedMaintenance.Domain.Entities.PlannedMaintenanceTask> listPresenter)
        {
            _listUseCase = listUseCase;
            _listPresenter = listPresenter;
        }

        [HttpPost("ListByParent")]
        public async Task<ActionResult> PagedList([FromBody] ListRequest<Quiplogs.PlannedMaintenance.Domain.Entities.PlannedMaintenanceTask> request)
        {
            if (!ModelState.IsValid)
            {
                // re-render the view when validation failed.
                return BadRequest(ModelState);
            }

            await _listUseCase.Handle(new ListRequest<Quiplogs.PlannedMaintenance.Domain.Entities.PlannedMaintenanceTask>(request.CompanyId, request.LocationId, request.ParentId, request.FilterParameters), _listPresenter);
            return _listPresenter.ContentResult;
        }
    }
}