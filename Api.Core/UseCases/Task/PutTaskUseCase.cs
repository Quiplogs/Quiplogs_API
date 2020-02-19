using Api.Core.Dto;
using Api.Core.Dto.Requests.Task;
using Api.Core.Dto.Responses.Task;
using Api.Core.Interfaces;
using Api.Core.Interfaces.Repositories;
using Api.Core.Interfaces.UseCases.Task;
using System.Threading.Tasks;

namespace Api.Core.UseCases.Task
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