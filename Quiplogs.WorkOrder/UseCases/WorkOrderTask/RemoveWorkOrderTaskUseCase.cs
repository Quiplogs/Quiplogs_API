using Api.Core;
using Api.Core.Dto;
using Api.Core.Interfaces;
using Quiplogs.WorkOrder.Dto.Requests.WorkOrderTask;
using Quiplogs.WorkOrder.Dto.Responses.WorkOrderTask;
using Quiplogs.WorkOrder.Interfaces.Repositories;
using Quiplogs.WorkOrder.Interfaces.UseCases.WorkOrderTask;
using System.Threading.Tasks;

namespace Quiplogs.WorkOrder.UseCases.WorkOrderTask
{
    public class RemoveWorkOrderTaskUseCase : IRemoveWorkOrderTaskUseCase
    {
        private readonly IWorkOrderTaskRepository _repository;

        public RemoveWorkOrderTaskUseCase(IWorkOrderTaskRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(RemoveWorkOrderTaskRequest message, IOutputPort<RemoveWorkOrderTaskResponse> outputPort)
        {
            var response = await _repository.Remove(message.Id);
            if (response.Success)
            {
                outputPort.Handle(new RemoveWorkOrderTaskResponse(response.Description, true));
                return true;
            }

            outputPort.Handle(new RemoveWorkOrderTaskResponse(new[] { new Error(GlobalVariables.error_workOrderTaskFailure, "Error removing Work Order Task.") }));
            return false;
        }
    }
}
