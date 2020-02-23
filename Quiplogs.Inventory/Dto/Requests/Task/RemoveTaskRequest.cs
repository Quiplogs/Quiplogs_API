using Api.Core.Interfaces;
using Quiplogs.Inventory.Dto.Responses.Task;

namespace Quiplogs.Inventory.Dto.Requests.Task
{
    public class RemoveTaskRequest : IRequest<RemoveTaskResponse>
    {
        public string Id { get; }
        public RemoveTaskRequest(string id)
        {
            Id = id;
        }
    }
}
