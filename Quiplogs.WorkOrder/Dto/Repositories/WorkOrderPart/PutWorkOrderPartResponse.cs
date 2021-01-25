using System.Collections.Generic;
using Quiplogs.Core.Dto;
using Quiplogs.Core.Dto.Repositories;

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
