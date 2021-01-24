using Api.Core.Interfaces;
using Quiplogs.WorkOrder.Dto.Responses.WorkOrderTask;
using System;

namespace Quiplogs.WorkOrder.Dto.Requests.WorkOrderTask
{
    public class ListWorkOrderTaskRequest : IRequest<ListWorkOrderTaskResponse>
    {
        public Guid WorkOrderId { get; }
        public int PageNumber { get; }
        public ListWorkOrderTaskRequest(Guid workOrderId, int pageNumber)
        {
            WorkOrderId = workOrderId;
            PageNumber = pageNumber;
        }
    }
}
