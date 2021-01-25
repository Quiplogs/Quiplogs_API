using System.Collections.Generic;
using Quiplogs.Core.Dto;
using Quiplogs.Core.Interfaces;

namespace Quiplogs.WorkOrder.Dto.Responses.WorkOrderTask
{
    public class PutWorkOrderTaskResponse : ServiceResponseMessage
    {
        public Domain.Entities.WorkOrderTask WorkOrderTask { get; }
        public IEnumerable<Error> Errors { get; }

        public PutWorkOrderTaskResponse(IEnumerable<Error> errors, bool success = false, string message = null) : base(success, message)
        {
            Errors = errors;
        }

        public PutWorkOrderTaskResponse(Domain.Entities.WorkOrderTask workOrderTask, bool success = false, string message = null) : base(success, message)
        {
            WorkOrderTask = workOrderTask;
        }
    }
}
