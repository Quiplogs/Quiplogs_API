using Api.Core;
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
            var response = await _repository.List(message.PlannedMaintenanceId);

            if (response.Success)
            { 
                outputPort.Handle(new ListPlannedMaintenancePartResponse(response.PlannedMaintenanceParts, true));
                return true;
            }

            outputPort.Handle(new ListPlannedMaintenancePartResponse(new[] { new Error(GlobalVariables.error_plannedMaintenancePartFailure, "No Planned Maintenances Parts Found.") }));
            return false;
        }
    }
}
