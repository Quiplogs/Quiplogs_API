using Api.Core.Dto;
using Api.Core.Dto.Repositories;
using Api.Core.Dto.Responses;
using System.Collections.Generic;

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

