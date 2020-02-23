using Api.Core.Interfaces;
using Quiplogs.Inventory.Dto.Requests.Task;
using Quiplogs.Inventory.Dto.Responses.Task;

namespace Quiplogs.Inventory.Interfaces.UseCases.Task
{
    public interface IRemoveTaskUseCase : IRequestHandler<RemoveTaskRequest, RemoveTaskResponse>
    {
    }
}
