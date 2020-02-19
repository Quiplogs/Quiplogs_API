using Api.Core.Dto.Responses.Task;
using Api.Core.Interfaces;

namespace Api.Core.Dto.Requests.Task
{
    public class PutTaskRequest : IRequest<PutTaskResponse>
    {
        public Domain.Entities.TaskEntity Task { get; }
        public PutTaskRequest(Domain.Entities.TaskEntity task)
        {
            Task = task;
        }
    }
}
