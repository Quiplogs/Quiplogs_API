using Api.Core.Interfaces;
using Quiplogs.Inventory.Dto.Responses.Task;

namespace Quiplogs.Inventory.Dto.Requests.Task
{
    public class GetTaskRequest : IRequest<GetTaskResponse>
    {
        public string Id { get; }
        public GetTaskRequest(string id)
        {
            Id = id;
        }
    }
}
