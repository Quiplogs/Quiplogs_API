using Quiplogs.WorkOrder.Dto.Requests.PlannedMaintenanceTask;
using Quiplogs.WorkOrder.Dto.Responses.PlannedMaintenanceTask;
using Quiplogs.WorkOrder.Interfaces.Repositories;
using Quiplogs.WorkOrder.Interfaces.UseCases.PlannedMaintenanceTask;
using System.Threading.Tasks;
using Quiplogs.Core.Dto;
using Quiplogs.Core.Interfaces;

namespace Quiplogs.WorkOrder.UseCases.PlannedMaintenanceTask
{
    public class ListPlannedMaintenanceTaskUseCase : IListPlannedMaintenanceTaskUseCase
    {
        private readonly IPlannedMaintenanceTaskRepository _repository;

        public ListPlannedMaintenanceTaskUseCase(IPlannedMaintenanceTaskRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(ListPlannedMaintenanceTaskRequest message, IOutputPort<ListPlannedMaintenanceTaskResponse> outputPort)
        {
            var response = await _repository.List(message.PlannedMaintenanceId);
            if (response.Success)
            {
                outputPort.Handle(new ListPlannedMaintenanceTaskResponse(response.PlannedMaintenanceTasks, true));
                return true;
            }

            outputPort.Handle(new ListPlannedMaintenanceTaskResponse(new[] { new Error("", "No Planned Maintenances Tasks Found.") }));
            return false;
        }
    }
}
