using Api.Core;
using Api.Core.Domain.Entities;
using Api.Core.Dto;
using Api.Core.Interfaces;
using Quiplogs.WorkOrder.Dto.Requests.PlannedMaintenanceTask;
using Quiplogs.WorkOrder.Dto.Responses.PlannedMaintenanceTask;
using Quiplogs.WorkOrder.Interfaces.Repositories;
using Quiplogs.WorkOrder.Interfaces.UseCases.PlannedMaintenanceTask;
using System.Threading.Tasks;

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
            //temp var
            var pageSize = 20;

            var response = await _repository.List(message.PlannedMaintenanceId, message.PageNumber, pageSize);
            if (response.Success)
            {
                var total = _repository.GetTotalRecords(message.PlannedMaintenanceId);
                var pagedResult = new PagedResult<Domain.Entities.PlannedMaintenanceTask>(response.PlannedMaintenanceTasks, total, message.PageNumber, pageSize);

                outputPort.Handle(new ListPlannedMaintenanceTaskResponse(pagedResult, true));
                return true;
            }

            outputPort.Handle(new ListPlannedMaintenanceTaskResponse(new[] { new Error(GlobalVariables.error_plannedMaintenanceTaskFailure, "No Planned Maintenances Tasks Found.") }));
            return false;
        }
    }
}
