using Api.Core.Interfaces;
using Quiplogs.WorkOrder.Dto.Responses.WorkOrderPart;

namespace Quiplogs.WorkOrder.Dto.Requests.WorkOrderPart
{
    public class ListWorkOrderPartRequest : IRequest<ListWorkOrderPartResponse>
    {
        public string WorkOrderId { get; }
        public int PageNumber { get; }
        public ListWorkOrderPartRequest(string workOrderId, int pageNumber)
        {
            WorkOrderId = workOrderId;
            PageNumber = pageNumber;
        }
    }
}
