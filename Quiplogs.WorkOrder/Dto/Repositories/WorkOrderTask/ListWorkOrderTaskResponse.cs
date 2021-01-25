using System.Collections.Generic;
using Quiplogs.Core.Dto;
using Quiplogs.Core.Dto.Repositories;

namespace Quiplogs.WorkOrder.Dto.Repositories.WorkOrderTask
{
    public class ListWorkOrderTaskResponse : BaseRepositoryResponse
    {
        public List<Domain.Entities.WorkOrderTask> WorkOrderTasks { get; set; }

        public ListWorkOrderTaskResponse(List<Domain.Entities.WorkOrderTask> workOrderTasks, bool success = false, IEnumerable<Error> errors = null) : base(success, errors)
        {
            WorkOrderTasks = workOrderTasks;
        }
    }
}
