using Api.Core.Dto;
using Api.Core.Dto.Repositories;
using System.Collections.Generic;

namespace Quiplogs.WorkOrder.Dto.Repositories.WorkOrder
{
    public class GetWorkOrderResponse : BaseRepositoryResponse
    {
        public Domain.Entities.WorkOrderEntity WorkOrder { get; set; }

        public GetWorkOrderResponse(Domain.Entities.WorkOrderEntity workOrder, bool success = false, IEnumerable<Error> errors = null) : base(success, errors)
        {
            WorkOrder = workOrder;
        }
    }
}
