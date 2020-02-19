using Api.Core.Dto.Requests.Task;
using Api.Core.Dto.Responses.Task;

namespace Api.Core.Interfaces.UseCases.Task
{
    public interface IRemoveTaskUseCase : IRequestHandler<RemoveTaskRequest, RemoveTaskResponse>
    {
    }
}
