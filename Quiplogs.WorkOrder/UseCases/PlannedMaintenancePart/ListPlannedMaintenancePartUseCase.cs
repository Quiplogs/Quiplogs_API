using Api.Core;
using Api.Core.Domain.Entities;
using Api.Core.Dto;
using Api.Core.Interfaces;
using Quiplogs.WorkOrder.Dto.Requests.PlannedMaintenancePart;
using Quiplogs.WorkOrder.Dto.Responses.PlannedMaintenancePart;
using Quiplogs.WorkOrder.Interfaces.Repositories;
using Quiplogs.WorkOrder.Interfaces.UseCases.PlannedMaintenancePart;
using System.Threading.Tasks;

namespace Quiplogs.WorkOrder.UseCases.PlannedMaintenancePartPart
{
    public class ListPlannedMaintenancePartUseCase : IListPlannedMaintenancePartUseCase
    {
        private readonly IPlannedMaintenancePartRepository _repository;

        public ListPlannedMaintenancePartUseCase(IPlannedMaintenancePartRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(ListPlannedMaintenancePartRequest message, IOutputPort<ListPlannedMaintenancePartResponse> outputPort)
        {
            //temp var
            var pageSize = 20;

            var response = await _repository.List(message.PlannedMaintenanceId, message.PageNumber, pageSize);
            if (response.Success)
            {
                var total = _repository.GetTotalRecords(message.PlannedMaintenanceId);
                var pagedResult = new PagedResult<Domain.Entities.PlannedMaintenancePart>(response.PlannedMaintenanceParts, total, message.PageNumber, pageSize);

                outputPort.Handle(new ListPlannedMaintenancePartResponse(pagedResult, true));
                return true;
            }

            outputPort.Handle(new ListPlannedMaintenancePartResponse(new[] { new Error(GlobalVariables.error_plannedMaintenancePartFailure, "No Planned Maintenances Parts Found.") }));
            return false;
        }
    }
}
