using Api.Core.Interfaces;
using Quiplogs.Inventory.Dto.Responses.Task;

namespace Quiplogs.Inventory.Dto.Requests.Task
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
