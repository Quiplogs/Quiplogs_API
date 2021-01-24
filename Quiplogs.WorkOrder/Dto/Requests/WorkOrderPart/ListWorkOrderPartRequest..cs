using Api.Core.Interfaces;
using Quiplogs.WorkOrder.Dto.Responses.WorkOrderPart;
using System;

namespace Quiplogs.WorkOrder.Dto.Requests.WorkOrderPart
{
    public class ListWorkOrderPartRequest : IRequest<ListWorkOrderPartResponse>
    {
        public Guid WorkOrderId { get; }
        public int PageNumber { get; }
        public ListWorkOrderPartRequest(Guid workOrderId, int pageNumber)
        {
            WorkOrderId = workOrderId;
            PageNumber = pageNumber;
        }
    }
}
