using Api.Core.Dto;
using Api.Core.Dto.Responses;
using System.Collections.Generic;

namespace Quiplogs.WorkOrder.Dto.Repositories.WorkOrder
{
    public class PutWorkOrderTaskResponse : BaseResponse
    {
        public Domain.Entities.WorkOrderTask WorkOrderTask { get; set; }

        public PutWorkOrderTaskResponse(Domain.Entities.WorkOrderTask workOrderTask, bool success = false, IEnumerable<Error> errors = null) : base(success, errors)
        {
            WorkOrderTask = workOrderTask;
        }
    }
}

