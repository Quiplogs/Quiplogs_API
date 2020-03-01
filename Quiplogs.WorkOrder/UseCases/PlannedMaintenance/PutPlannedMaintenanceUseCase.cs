using Api.Core;
using Api.Core.Dto;
using Api.Core.Interfaces;
using Quiplogs.PlannedMaintenance.Interfaces.UseCases.PlannedMaintenance;
using Quiplogs.WorkOrder.Dto.Requests.PlannedMaintenance;
using Quiplogs.WorkOrder.Dto.Responses.PlannedMaintenance;
using Quiplogs.WorkOrder.Interfaces.Repositories;
using System.Threading.Tasks;

namespace Quiplogs.WorkOrder.UseCases.PlannedMaintenance
{
    public class PutPlannedMaintenanceUseCase : IPutPlannedMaintenanceUseCase
    {
        private readonly IPlannedMaintenanceRepository _repository;

        public PutPlannedMaintenanceUseCase(IPlannedMaintenanceRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(PutPlannedMaintenanceRequest message, IOutputPort<PutPlannedMaintenanceResponse> outputPort)
        {
            var response = await _repository.Put(message.PlannedMaintenance);
            if (response.Success)
            {
                outputPort.Handle(new PutPlannedMaintenanceResponse(response.PlannedMaintenance, true));
                return true;
            }

            outputPort.Handle(new PutPlannedMaintenanceResponse(new[] { new Error(GlobalVariables.error_plannedMaintenanceFailure, "Error updating PlannedMaintenance.") }));
            return false;
        }
    }
}
