using Api.Core.Dto.Responses.Task;
using Api.Core.Interfaces;

namespace Api.Core.Dto.Requests.Task
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
