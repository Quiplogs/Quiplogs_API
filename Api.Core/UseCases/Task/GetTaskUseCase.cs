using Api.Core.Dto;
using Api.Core.Dto.Requests.Task;
using Api.Core.Dto.Responses.Task;
using Api.Core.Interfaces;
using Api.Core.Interfaces.Repositories;
using Api.Core.Interfaces.UseCases.Task;
using System.Threading.Tasks;

namespace Api.Core.UseCases.Task
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
