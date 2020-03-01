using Api.Core.Interfaces;
using Quiplogs.WorkOrder.Dto.Responses.WorkOrderPart;

namespace Quiplogs.WorkOrder.Dto.Requests.WorkOrderPart
{
    public class RemoveWorkOrderPartRequest : IRequest<RemoveWorkOrderPartResponse>
    {
        public string Id { get; }
        public RemoveWorkOrderPartRequest(string id)
        {
            Id = id;
        }
    }
}
