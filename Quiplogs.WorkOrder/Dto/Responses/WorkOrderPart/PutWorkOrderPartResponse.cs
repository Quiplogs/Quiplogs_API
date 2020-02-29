using Api.Core.Dto;
using Api.Core.Interfaces;
using System.Collections.Generic;

namespace Quiplogs.WorkOrder.Dto.Responses.WorkOrderPart
{
    public class PutWorkOrderPartResponse : ServiceResponseMessage
    {
        public Domain.Entities.WorkOrderPart WorkOrderPart { get; }
        public IEnumerable<Error> Errors { get; }

        public PutWorkOrderPartResponse(IEnumerable<Error> errors, bool success = false, string message = null) : base(success, message)
        {
            Errors = errors;
        }

        public PutWorkOrderPartResponse(Domain.Entities.WorkOrderPart workOrderPart, bool success = false, string message = null) : base(success, message)
        {
            WorkOrderPart = workOrderPart;
        }
    }
}
