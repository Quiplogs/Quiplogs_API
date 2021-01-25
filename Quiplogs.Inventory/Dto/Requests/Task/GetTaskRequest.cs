using Quiplogs.Inventory.Dto.Responses.Task;
using System;
using Quiplogs.Core.Interfaces;

namespace Quiplogs.Inventory.Dto.Requests.Task
{
    public class GetTaskRequest : IRequest<GetTaskResponse>
    {
        public Guid Id { get; }
        public GetTaskRequest(Guid id)
        {
            Id = id;
        }
    }
}
