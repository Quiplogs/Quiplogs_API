using Api.Core.Interfaces;
using Quiplogs.Inventory.Dto.Responses.Task;
using System;

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
