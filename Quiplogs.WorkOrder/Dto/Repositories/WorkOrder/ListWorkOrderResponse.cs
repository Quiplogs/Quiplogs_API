using System.Collections.Generic;
using Quiplogs.Core.Dto;
using Quiplogs.Core.Dto.Repositories;

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
