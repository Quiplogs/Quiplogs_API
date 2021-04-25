using Microsoft.EntityFrameworkCore;
using Quiplogs.Core.Dto.Requests.Generic;
using Quiplogs.Core.Dto.Responses.Generic;
using Quiplogs.Core.Interfaces;
using Quiplogs.Core.Interfaces.Repositories;
using Quiplogs.Core.Interfaces.UseCases.Generic;
using Quiplogs.WorkOrder.Data.Entities;
using System.Threading.Tasks;

namespace Quiplogs.WorkOrder.UseCases.WorkOrderPart
{
    public class PutWorkOrderPartUseCase : IPutUseCase<Domain.Entities.WorkOrderPart, WorkOrderPartDto>
    {
        private readonly IBaseRepository<Domain.Entities.WorkOrderPart, WorkOrderPartDto> _baseRepository;

        public PutWorkOrderPartUseCase(
            IBaseRepository<Domain.Entities.WorkOrderPart,
                WorkOrderPartDto> baseRepository)
        {
            _baseRepository = baseRepository;
        }

        public async Task<bool> Handle(PutRequest<Domain.Entities.WorkOrderPart> request, IOutputPort<PutResponse<Domain.Entities.WorkOrderPart>> outputPort)
        {
            request.Model.Company = null;
            request.Model.Part = null;
            request.Model.WorkOrder = null;

            var response = await _baseRepository.Put(request.Model);
            if (response.Success)
            {
                var updatedModelResponse = await _baseRepository.GetById(request.Model.Id, including: source => source.Include(model => model.Part));
                outputPort.Handle(new PutResponse<Domain.Entities.WorkOrderPart>(updatedModelResponse.Model, true));
                return true;
            }

            outputPort.Handle(new PutResponse<Domain.Entities.WorkOrderPart>(response.Errors));
            return false;
        }
    }
}
