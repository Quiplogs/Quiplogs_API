using Api.Core;
using Api.Core.Dto;
using Api.Core.Interfaces;
using Quiplogs.Inventory.Dto.Requests.Task;
using Quiplogs.Inventory.Dto.Responses.Task;
using Quiplogs.Inventory.Interfaces.Repositories;
using Quiplogs.Inventory.Interfaces.UseCases.Task;
using System.Threading.Tasks;

namespace Quiplogs.Inventory.UseCases.Task
{
    public class GetTaskUseCase : IGetTaskUseCase
    {
        private readonly ITaskRepository _repository;

        public GetTaskUseCase(ITaskRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(GetTaskRequest message, IOutputPort<GetTaskResponse> outputPort)
        {
            var response = await _repository.Get(message.Id);
            if (response.Success)
            {
                outputPort.Handle(new GetTaskResponse(response.Task, true));
                return true;
            }

            outputPort.Handle(new GetTaskResponse(new[] { new Error(GlobalVariables.error_taskFailure, "Task not Found.") }));
            return false;
        }
    }
}
