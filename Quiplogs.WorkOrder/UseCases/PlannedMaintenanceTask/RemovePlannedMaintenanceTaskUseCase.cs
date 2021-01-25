using Quiplogs.WorkOrder.Dto.Requests.PlannedMaintenanceTask;
using Quiplogs.WorkOrder.Dto.Responses.PlannedMaintenanceTask;
using Quiplogs.WorkOrder.Interfaces.Repositories;
using Quiplogs.WorkOrder.Interfaces.UseCases.PlannedMaintenanceTask;
using System.Threading.Tasks;
using Quiplogs.Core.Dto;
using Quiplogs.Core.Interfaces;

namespace Quiplogs.WorkOrder.UseCases.PlannedMaintenanceTask
{
    public class RemovePlannedMaintenanceTaskUseCase : IRemovePlannedMaintenanceTaskUseCase
    {
        private readonly IPlannedMaintenanceTaskRepository _repository;

        public RemovePlannedMaintenanceTaskUseCase(IPlannedMaintenanceTaskRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(RemovePlannedMaintenanceTaskRequest message, IOutputPort<RemovePlannedMaintenanceTaskResponse> outputPort)
        {
            var response = await _repository.Remove(message.Id);
            if (response.Success)
            {
                outputPort.Handle(new RemovePlannedMaintenanceTaskResponse(response.Description, true));
                return true;
            }

            outputPort.Handle(new RemovePlannedMaintenanceTaskResponse(new[] { new Error("", "Error removing Planned Maintenance Task.") }));
            return false;
        }
    }
}
