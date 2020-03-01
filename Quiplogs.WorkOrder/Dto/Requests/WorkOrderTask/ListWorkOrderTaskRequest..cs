using Api.Core.Interfaces;
using Quiplogs.WorkOrder.Dto.Responses.WorkOrderTask;

namespace Quiplogs.WorkOrder.Dto.Requests.WorkOrderTask
{
    public class ListWorkOrderTaskRequest : IRequest<ListWorkOrderTaskResponse>
    {
        public string WorkOrderId { get; }
        public int PageNumber { get; }
        public ListWorkOrderTaskRequest(string workOrderId, int pageNumber)
        {
            WorkOrderId = workOrderId;
            PageNumber = pageNumber;
        }
    }
}
