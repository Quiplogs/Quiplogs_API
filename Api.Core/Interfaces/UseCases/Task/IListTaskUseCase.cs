using Api.Core.Dto.Requests.Task;
using Api.Core.Dto.Responses.Task;

namespace Api.Core.Interfaces.UseCases.Task
{
    public interface IListTaskUseCase : IRequestHandler<ListTaskRequest, ListTaskResponse>
    {
    }
}
