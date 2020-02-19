using Api.Core.Dto.Responses.Task;
using Api.Core.Interfaces;
namespace Api.Core.Dto.Requests.Task
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
