using Api.Core.Interfaces;
using Quiplogs.Inventory.Dto.Responses.Task;
using System;

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
