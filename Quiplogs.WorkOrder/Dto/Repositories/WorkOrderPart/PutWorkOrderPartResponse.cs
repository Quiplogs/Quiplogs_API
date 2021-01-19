using Api.Core.Dto;
using Api.Core.Dto.Responses;
using System.Collections.Generic;

namespace Quiplogs.WorkOrder.Dto.Repositories.WorkOrderPart
{
    public class PutWorkOrderPartResponse : BaseRepositoryResponse
    {
        public Domain.Entities.WorkOrderPart WorkOrderPart { get; set; }

        public PutWorkOrderPartResponse(Domain.Entities.WorkOrderPart workOrderPart, bool success = false, IEnumerable<Error> errors = null) : base(success, errors)
        {
            WorkOrderPart = workOrderPart;
        }
    }
}
