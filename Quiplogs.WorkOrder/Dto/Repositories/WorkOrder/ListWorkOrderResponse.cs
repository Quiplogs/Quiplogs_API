﻿using Api.Core.Dto;
using Api.Core.Dto.Responses;
using System.Collections.Generic;

namespace Quiplogs.WorkOrder.Dto.Repositories.WorkOrder
{
    public class ListWorkOrderResponse : BaseResponse
    {
        public List<Domain.Entities.WorkOrder> WorkOrders { get; set; }

        public ListWorkOrderResponse(List<Domain.Entities.WorkOrder> workOrders, bool success = false, IEnumerable<Error> errors = null) : base(success, errors)
        {
            WorkOrders = workOrders;
        }
    }
}
