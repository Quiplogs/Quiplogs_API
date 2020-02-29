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
    public class PutPlannedMaintenancePartUseCase : IPutPlannedMaintenancePartUseCase
    {
        private readonly IPlannedMaintenancePartRepository _repository;

        public PutPlannedMaintenancePartUseCase(IPlannedMaintenancePartRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(PutPlannedMaintenancePartRequest message, IOutputPort<PutPlannedMaintenancePartResponse> outputPort)
        {
            var response = await _repository.Put(message.PlannedMaintenancePart);
            if (response.Success)
            {
                outputPort.Handle(new PutPlannedMaintenancePartResponse(response.PlannedMaintenancePart, true));
                return true;
            }

            outputPort.Handle(new PutPlannedMaintenancePartResponse(new[] { new Error(GlobalVariables.error_plannedMaintenancePartFailure, "Error updating Planned Maintenance Part.") }));
            return false;
        }
    }
}
