using Api.Core.Interfaces;
using Quiplogs.WorkOrder.Dto.Responses.WorkOrderPart;
using System;

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
