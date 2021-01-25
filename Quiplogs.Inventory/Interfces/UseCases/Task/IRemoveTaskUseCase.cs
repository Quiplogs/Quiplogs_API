using Quiplogs.Core.Interfaces;
using Quiplogs.Inventory.Dto.Requests.Task;
using Quiplogs.Inventory.Dto.Responses.Task;

namespace Quiplogs.Inventory.Interfces.UseCases.Task
{
    public interface IRemoveTaskUseCase : IRequestHandler<RemoveTaskRequest, RemoveTaskResponse>
    {
    }
}
