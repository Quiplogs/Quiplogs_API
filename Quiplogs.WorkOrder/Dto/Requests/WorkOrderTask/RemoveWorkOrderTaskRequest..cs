using Api.Core.Interfaces;
using Quiplogs.WorkOrder.Dto.Responses.WorkOrderTask;
using System;

namespace Quiplogs.WorkOrder.Dto.Requests.WorkOrderTask
{
    public class RemoveWorkOrderTaskRequest : IRequest<RemoveWorkOrderTaskResponse>
    {
        public Guid Id { get; }
        public RemoveWorkOrderTaskRequest(Guid id)
        {
            Id = id;
        }
    }
}
