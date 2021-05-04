using Microsoft.EntityFrameworkCore;
using Quiplogs.Core.Dto.Requests.Generic;
using Quiplogs.Core.Dto.Responses.Generic;
using Quiplogs.Core.Interfaces;
using Quiplogs.Core.Interfaces.Repositories;
using Quiplogs.Core.Interfaces.UseCases.Generic;
using Quiplogs.WorkOrder.Data.Entities;
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
            var response = await _baseRepository.PagedList(
                request.CompanyId,
                request.PageNumber,
                request.PageSize,
                request.FilterParameters,
                model => !request.LocationId.HasValue || model.LocationId == request.LocationId.Value && model.CompanyId == request.CompanyId,
                source => source
                    .Include(model => model.Asset)
                    .Include(model => model.Location)
                    .Include(model => model.Technician));

            if (response.Success)
            {
                outputPort.Handle(new PagedResponse<Domain.Entities.WorkOrderEntity>(response.PagedResult, true));
                return true;
            }

            outputPort.Handle(new PagedResponse<Domain.Entities.WorkOrderEntity>(response.Errors));
            return false;
        }
    }
}
