using Quiplogs.Inventory.Dto.Responses.Task;
using System;
using Quiplogs.Core.Interfaces;

namespace Quiplogs.Inventory.Dto.Requests.Task
{
    public class RemoveTaskRequest : IRequest<RemoveTaskResponse>
    {
        public Guid Id { get; }
        public RemoveTaskRequest(Guid id)
        {
            Id = id;
        }
    }
}
