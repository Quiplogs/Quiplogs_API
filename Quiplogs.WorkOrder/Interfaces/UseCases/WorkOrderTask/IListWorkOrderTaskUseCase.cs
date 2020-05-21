﻿using Api.Core.Interfaces;
using Quiplogs.WorkOrder.Dto.Requests.WorkOrderTask;
using Quiplogs.WorkOrder.Dto.Responses.WorkOrderTask;

namespace Quiplogs.WorkOrder.Interfaces.UseCases.WorkOrderTask
{
    public interface IListWorkOrderTaskUseCase : IRequestHandler<ListWorkOrderTaskRequest, ListWorkOrderTaskResponse>
    {
    }
}