using Quiplogs.Core.Dto;
using Quiplogs.Core.Dto.Requests.Generic;
using Quiplogs.Core.Dto.Responses.Generic;
using Quiplogs.Core.Interfaces;
using Quiplogs.Core.Interfaces.Repositories;
using Quiplogs.Core.Interfaces.UseCases.Generic;
using Quiplogs.WorkOrder.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Quiplogs.WorkOrder.UseCases.WorkOrder
{
    public class WorkOrderPagedListUseCase : IPagedListUseCase<Domain.Entities.WorkOrderEntity, WorkOrderDto>
    {
        private readonly IBaseRepository<Domain.Entities.WorkOrderEntity, WorkOrderDto> _baseRepository;

        public WorkOrderPagedListUseCase(IBaseRepository<Domain.Entities.WorkOrderEntity, WorkOrderDto> baseRepository)
        {
            _baseRepository = baseRepository;
        }

        public async Task<bool> Handle(PagedRequest<Domain.Entities.WorkOrderEntity> request, IOutputPort<PagedResponse<Domain.Entities.WorkOrderEntity>> outputPort)
        {
            var includes = new List<Expression<Func<WorkOrderDto, object>>>();
            includes.Add(model => model.WorkOrderParts);
            includes.Add(model => model.WorkOrderTasks);

            var response = await _baseRepository.PagedList(
                request.CompanyId,
                request.PageNumber,
                request.PageSize,
                request.FilterParameters,
                model => !request.LocationId.HasValue || model.LocationId == request.LocationId.Value,
                includes);

            if (response.Success)
            {
                outputPort.Handle(new PagedResponse<Domain.Entities.WorkOrderEntity>(response.PagedResult, true));
                return true;
            }

            outputPort.Handle(new PagedResponse<Domain.Entities.WorkOrderEntity>(new[] { new Error("", "Model not Found.") }));
            return false;
        }
    }
}
