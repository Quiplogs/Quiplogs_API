using Quiplogs.WorkOrder.Dto.Responses.WorkOrderPart;
using System;
using Quiplogs.Core.Interfaces;

namespace Quiplogs.WorkOrder.Dto.Requests.WorkOrderPart
{
    public class RemoveWorkOrderPartRequest : IRequest<RemoveWorkOrderPartResponse>
    {
        public Guid Id { get; }
        public RemoveWorkOrderPartRequest(Guid id)
        {
            Id = id;
        }
    }
}
