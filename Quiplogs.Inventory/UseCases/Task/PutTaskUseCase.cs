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
    public class PutTaskUseCase : IPutTaskUseCase
    {
        private readonly ITaskRepository _repository;

        public PutTaskUseCase(ITaskRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(PutTaskRequest message, IOutputPort<PutTaskResponse> outputPort)
        {
            var response = await _repository.Put(message.Task);
            if (response.Success)
            {
                outputPort.Handle(new PutTaskResponse(response.Task, true));
                return true;
            }

            outputPort.Handle(new PutTaskResponse(new[] { new Error(GlobalVariables.error_taskFailure, "Error updating Task.") }));
            return false;
        }
    }
}