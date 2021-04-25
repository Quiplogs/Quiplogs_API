using Quiplogs.Core.Dto.Requests.Generic;
using Quiplogs.Core.Dto.Responses.Generic;
using Quiplogs.Core.Interfaces;
using Quiplogs.Core.Interfaces.Repositories;
using Quiplogs.Core.Interfaces.UseCases.Generic;
using Quiplogs.WorkOrder.Data.Entities;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Quiplogs.WorkOrder.UseCases.WorkOrder
{
    public class GetWorkOrderUseCase : IGetUseCase<Domain.Entities.WorkOrderEntity, WorkOrderDto>
    {
        private readonly IBaseRepository<Domain.Entities.WorkOrderEntity, WorkOrderDto> _baseRepository;

        public GetWorkOrderUseCase(IBaseRepository<Domain.Entities.WorkOrderEntity, WorkOrderDto> baseRepository)
        {
            _baseRepository = baseRepository;
        }

        public async Task<bool> Handle(GetRequest<Domain.Entities.WorkOrderEntity> request, IOutputPort<GetResponse<Domain.Entities.WorkOrderEntity>> outputPort)
        {
            var response = await _baseRepository.GetById(request.Id,
                source => source
                    .Include(model => model.Location)
                    .Include(model => model.Asset)
                    .Include(model => model.WorkOrderTasks)
                    .Include(model => model.WorkOrderParts)
                        .ThenInclude(model => model.Part)
                    .Include(model => model.Technician));

            if (response.Success)
            {
                outputPort.Handle(new GetResponse<Domain.Entities.WorkOrderEntity>(response.Model, true));
                return true;
            }

            outputPort.Handle(new GetResponse<Domain.Entities.WorkOrderEntity>(response.Errors));
            return false;
        }
    }
}
