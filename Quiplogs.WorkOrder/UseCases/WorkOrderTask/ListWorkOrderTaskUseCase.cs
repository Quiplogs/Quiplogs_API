using Quiplogs.Core.Dto;
using Quiplogs.Core.Dto.Requests.Generic;
using Quiplogs.Core.Dto.Responses.Generic;
using Quiplogs.Core.Interfaces;
using Quiplogs.Core.Interfaces.Repositories;
using Quiplogs.Core.Interfaces.UseCases.Generic;
using Quiplogs.WorkOrder.Data.Entities;
using System.Threading.Tasks;

namespace Quiplogs.WorkOrder.UseCases.WorkOrderTask
{
    public class ListWorkOrderTaskUseCase : IListUseCase<Domain.Entities.WorkOrderTask, WorkOrderTaskDto>
    {
        private readonly IBaseRepository<Domain.Entities.WorkOrderTask, WorkOrderTaskDto> _baseRepository;

        public ListWorkOrderTaskUseCase(IBaseRepository<Domain.Entities.WorkOrderTask, WorkOrderTaskDto> baseRepository)
        {
            _baseRepository = baseRepository;
        }

        public async Task<bool> Handle(ListRequest<Domain.Entities.WorkOrderTask> request, IOutputPort<ListResponse<Domain.Entities.WorkOrderTask>> outputPort)
        {
            var response = await _baseRepository.List(
                model => model.WorkOrderId == request.ParentId,
                request.FilterParameters);

            if (response.Success)
            {
                outputPort.Handle(new ListResponse<Domain.Entities.WorkOrderTask>(response.Models, true));
                return true;
            }

            outputPort.Handle(new ListResponse<Domain.Entities.WorkOrderTask>(new[] { new Error("", "Model not Found.") }));
            return false;
        }
    }
}
