﻿using System.Collections.Generic;
using Quiplogs.Core.Dto;
using Quiplogs.Core.Dto.Repositories;

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
