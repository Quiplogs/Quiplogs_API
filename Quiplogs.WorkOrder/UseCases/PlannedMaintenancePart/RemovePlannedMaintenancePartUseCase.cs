using System.Threading.Tasks;
using Quiplogs.Core.Dto;
using Quiplogs.Core.Interfaces;
using Quiplogs.WorkOrder.Dto.Requests.PlannedMaintenancePart;
using Quiplogs.WorkOrder.Dto.Responses.PlannedMaintenancePart;
using Quiplogs.WorkOrder.Interfaces.Repositories;
using Quiplogs.WorkOrder.Interfaces.UseCases.PlannedMaintenancePart;

namespace Quiplogs.WorkOrder.UseCases.PlannedMaintenancePart
{
    public class RemovePlannedMaintenancePartUseCase : IRemovePlannedMaintenancePartUseCase
    {
        private readonly IPlannedMaintenancePartRepository _repository;

        public RemovePlannedMaintenancePartUseCase(IPlannedMaintenancePartRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(RemovePlannedMaintenancePartRequest message, IOutputPort<RemovePlannedMaintenancePartResponse> outputPort)
        {
            var response = await _repository.Remove(message.Id);
            if (response.Success)
            {
                outputPort.Handle(new RemovePlannedMaintenancePartResponse(response.Description, true));
                return true;
            }

            outputPort.Handle(new RemovePlannedMaintenancePartResponse(new[] { new Error("", "Error removing Planned Maintenance Part.") }));
            return false;
        }
    }
}
