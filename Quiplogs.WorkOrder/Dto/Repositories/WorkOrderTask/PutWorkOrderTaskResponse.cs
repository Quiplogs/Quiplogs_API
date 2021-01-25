using System.Collections.Generic;
using Quiplogs.Core.Dto;
using Quiplogs.Core.Dto.Repositories;

namespace Quiplogs.WorkOrder.Dto.Repositories.WorkOrderTask
{
    public class PutWorkOrderTaskResponse : BaseRepositoryResponse
    {
        public Domain.Entities.WorkOrderTask WorkOrderTask { get; set; }

        public PutWorkOrderTaskResponse(Domain.Entities.WorkOrderTask workOrderTask, bool success = false, IEnumerable<Error> errors = null) : base(success, errors)
        {
            WorkOrderTask = workOrderTask;
        }
    }
}

