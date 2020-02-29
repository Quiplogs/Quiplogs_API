using Api.Core;
using Api.Core.Dto;
using Api.Core.Interfaces;
using Quiplogs.WorkOrder.Dto.Requests.PlannedMaintenanceTask;
using Quiplogs.WorkOrder.Dto.Responses.PlannedMaintenanceTask;
using Quiplogs.WorkOrder.Interfaces.Repositories;
using Quiplogs.WorkOrder.Interfaces.UseCases.PlannedMaintenanceTask;
using System.Threading.Tasks;

namespace Quiplogs.WorkOrder.UseCases.PlannedMaintenanceTask
{
    public class PutPlannedMaintenanceTaskUseCase : IPutPlannedMaintenanceTaskUseCase
    {
        private readonly IPlannedMaintenanceTaskRepository _repository;

        public PutPlannedMaintenanceTaskUseCase(IPlannedMaintenanceTaskRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(PutPlannedMaintenanceTaskRequest message, IOutputPort<PutPlannedMaintenanceTaskResponse> outputPort)
        {
            var response = await _repository.Put(message.PlannedMaintenanceTask);
            if (response.Success)
            {
                outputPort.Handle(new PutPlannedMaintenanceTaskResponse(response.PlannedMaintenanceTask, true));
                return true;
            }

            outputPort.Handle(new PutPlannedMaintenanceTaskResponse(new[] { new Error(GlobalVariables.error_plannedMaintenanceTaskFailure, "Error updating Planned Maintenance Task.") }));
            return false;
        }
    }
}
