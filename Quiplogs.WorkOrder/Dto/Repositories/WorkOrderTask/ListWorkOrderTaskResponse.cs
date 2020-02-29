using Api.Core.Dto;
using Api.Core.Dto.Responses;
using System.Collections.Generic;

namespace Quiplogs.WorkOrder.Dto.Repositories.WorkOrderTask
{
    public class ListWorkOrderTaskResponse : BaseResponse
    {
        public List<Domain.Entities.WorkOrderTask> WorkOrderTasks { get; set; }

        public ListWorkOrderTaskResponse(List<Domain.Entities.WorkOrderTask> workOrderTasks, bool success = false, IEnumerable<Error> errors = null) : base(success, errors)
        {
            WorkOrderTasks = workOrderTasks;
        }
    }
}
