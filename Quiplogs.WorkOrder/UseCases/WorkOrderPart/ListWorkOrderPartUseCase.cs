using Quiplogs.Core.Dto;
using Quiplogs.Core.Dto.Requests.Generic;
using Quiplogs.Core.Dto.Responses.Generic;
using Quiplogs.Core.Interfaces;
using Quiplogs.Core.Interfaces.Repositories;
using Quiplogs.Core.Interfaces.UseCases.Generic;
using Quiplogs.WorkOrder.Data.Entities;
using System.Threading.Tasks;

namespace Quiplogs.WorkOrder.UseCases.WorkOrderPart
{
    public class ListWorkOrderPartUseCase : IListUseCase<Domain.Entities.WorkOrderPart, WorkOrderPartDto>
    {
        private readonly IBaseRepository<Domain.Entities.WorkOrderPart, WorkOrderPartDto> _baseRepository;

        public ListWorkOrderPartUseCase(IBaseRepository<Domain.Entities.WorkOrderPart, WorkOrderPartDto> baseRepository)
        {
            _baseRepository = baseRepository;
        }

        public async Task<bool> Handle(ListRequest<Domain.Entities.WorkOrderPart> request,
            IOutputPort<ListResponse<Domain.Entities.WorkOrderPart>> outputPort)
        {
            var response = await _baseRepository.List(
                request.CompanyId,
                model => model.WorkOrderId == request.ParentId && model.CompanyId == request.CompanyId,
                request.FilterParameters);

            if (response.Success)
            {
                outputPort.Handle(new ListResponse<Domain.Entities.WorkOrderPart>(response.Models, true));
                return true;
            }

            outputPort.Handle(
                new ListResponse<Domain.Entities.WorkOrderPart>(new[] {new Error("", "Model not Found.")}));
            return false;
        }
    }
}