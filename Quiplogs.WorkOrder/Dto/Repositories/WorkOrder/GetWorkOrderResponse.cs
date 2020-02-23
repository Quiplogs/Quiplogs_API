using Api.Core.Dto;
using Api.Core.Dto.Responses;
using System.Collections.Generic;

namespace Quiplogs.WorkOrder.Dto.Repositories.WorkOrder
{
    public class GetWorkOrderResponse : BaseResponse
    {
        public Domain.Entities.WorkOrder WorkOrder { get; set; }

        public GetWorkOrderResponse(Domain.Entities.WorkOrder workOrder, bool success = false, IEnumerable<Error> errors = null) : base(success, errors)
        {
            WorkOrder = workOrder;
        }
    }
}
