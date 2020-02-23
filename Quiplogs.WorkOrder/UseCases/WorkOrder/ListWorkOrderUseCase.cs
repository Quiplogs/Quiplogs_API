using Api.Core;
using Api.Core.Domain.Entities;
using Api.Core.Dto;
using Api.Core.Interfaces;
using Quiplogs.WorkOrder.Dto.Requests.WorkOrder;
using Quiplogs.WorkOrder.Dto.Responses.WorkOrder;
using Quiplogs.WorkOrder.Interfaces.Repositories;
using Quiplogs.WorkOrder.Interfaces.UseCases.WorkOrder;
using System.Threading.Tasks;

namespace Quiplogs.WorkOrder.UseCases.WorkOrder
{
    public class ListWorkOrderUseCase : IListWorkOrderUseCase
    {
        private readonly IWorkOrderRepository _repository;

        public ListWorkOrderUseCase(IWorkOrderRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(ListWorkOrderRequest message, IOutputPort<ListWorkOrderResponse> outputPort)
        {
            //temp var
            var pageSize = 20;

            var response = await _repository.List(message.CompanyId, message.LocationId, message.PageNumber, pageSize);
            if (response.Success)
            {
                var total = await _repository.GetTotalRecords(message.CompanyId);
                var pagedResult = new PagedResult<Domain.Entities.WorkOrder>(response.WorkOrders, total, message.PageNumber, pageSize);

                outputPort.Handle(new ListWorkOrderResponse(pagedResult, true));
                return true;
            }

            outputPort.Handle(new ListWorkOrderResponse(new[] { new Error(GlobalVariables.error_workOrderFailure, "No WorkOrders Found.") }));
            return false;
        }
    }
}
