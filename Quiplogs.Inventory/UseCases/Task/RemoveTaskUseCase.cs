using Quiplogs.Inventory.Dto.Requests.Task;
using Quiplogs.Inventory.Dto.Responses.Task;
using System.Threading.Tasks;
using Quiplogs.Core.Dto;
using Quiplogs.Core.Interfaces;
using Quiplogs.Inventory.Interfces.Repositories;
using Quiplogs.Inventory.Interfces.UseCases.Task;

namespace Quiplogs.Inventory.UseCases.Task
{
    public class RemoveTaskUseCase : IRemoveTaskUseCase
    {
        private readonly ITaskRepository _repository;

        public RemoveTaskUseCase(ITaskRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(RemoveTaskRequest message, IOutputPort<RemoveTaskResponse> outputPort)
        {
            var response = await _repository.Remove(message.Id);
            if (response.Success)
            {
                outputPort.Handle(new RemoveTaskResponse(response.Description, true));
                return true;
            }

            outputPort.Handle(new RemoveTaskResponse(new[] { new Error("", "Error removing Task.") }));
            return false;
        }
    }
}
