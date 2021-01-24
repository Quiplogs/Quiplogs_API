using Api.Core.Dto;
using Api.Core.Dto.Repositories;
using Api.Core.Dto.Responses;
using System.Collections.Generic;

namespace Quiplogs.WorkOrder.Dto.Repositories.WorkOrder
{
    public class PutWorkOrderResponse : BaseRepositoryResponse
    {
        public Domain.Entities.WorkOrderEntity WorkOrder { get; set; }

        public PutWorkOrderResponse(Domain.Entities.WorkOrderEntity workOrder, bool success = false, IEnumerable<Error> errors = null) : base(success, errors)
        {
            WorkOrder = workOrder;
        }
    }
}
