using Api.Core.Dto;
using Api.Core.Dto.Repositories;
using Api.Core.Dto.Responses;
using System.Collections.Generic;

namespace Quiplogs.WorkOrder.Dto.Repositories.WorkOrder
{
    public class ListWorkOrderResponse : BaseRepositoryResponse
    {
        public List<Domain.Entities.WorkOrderEntity> WorkOrders { get; set; }

        public ListWorkOrderResponse(List<Domain.Entities.WorkOrderEntity> workOrders, bool success = false, IEnumerable<Error> errors = null) : base(success, errors)
        {
            WorkOrders = workOrders;
        }
    }
}
