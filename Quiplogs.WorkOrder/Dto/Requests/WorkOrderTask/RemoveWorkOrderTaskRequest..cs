using Api.Core.Interfaces;
using Quiplogs.WorkOrder.Dto.Responses.WorkOrderTask;

namespace Quiplogs.WorkOrder.Dto.Requests.WorkOrderTask
{
    public class RemoveWorkOrderTaskRequest : IRequest<RemoveWorkOrderTaskResponse>
    {
        public string Id { get; }
        public RemoveWorkOrderTaskRequest(string id)
        {
            Id = id;
        }
    }
}
