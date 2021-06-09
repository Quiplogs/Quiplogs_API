using System;
using Quiplogs.Core.Dto.Requests.Generic;
using Quiplogs.Core.Dto.Responses.Generic;
using Quiplogs.Core.Interfaces;
using Quiplogs.Core.Interfaces.Repositories;
using Quiplogs.Core.Interfaces.UseCases.Generic;
using Quiplogs.WorkOrder.Data.Entities;
using System.Threading.Tasks;

namespace Quiplogs.WorkOrder.UseCases.WorkOrder
{
    public class PutWorkOrderUseCase : IPutUseCase<Domain.Entities.WorkOrderEntity, WorkOrderDto>
    {
        private readonly IBaseRepository<Domain.Entities.WorkOrderEntity, WorkOrderDto> _baseRepository;

        public PutWorkOrderUseCase(
            IBaseRepository<Domain.Entities.WorkOrderEntity,
                WorkOrderDto> baseRepository)
        {
            _baseRepository = baseRepository;
        }

        public async Task<bool> Handle(PutRequest<Domain.Entities.WorkOrderEntity> request, IOutputPort<PutResponse<Domain.Entities.WorkOrderEntity>> outputPort)
        {
            //Set unnecessary models to null & set company Ids
            request.Model.Company = null;
            request.Model.WorkOrderParts.ForEach(workOrderPart =>
            {
                workOrderPart.CompanyId = request.Model.CompanyId;
                workOrderPart.Part = null;
            });
            request.Model.WorkOrderTasks.ForEach(task => task.CompanyId = request.Model.CompanyId);

            //If exists then check if tech has changed and send mail
            if (request.Model.Id != Guid.Empty)
            {
                var getResponse = await _baseRepository.GetById(request.Model.Id);

                if (getResponse.Model.TechnicianId != request.Model.TechnicianId)
                {
                    //send mail;
                }
            }

            var response = await _baseRepository.Put(request.Model);
            if (response.Success)
            {
                // try send mail
                try
                {

                }
                catch (Exception ex)
                {

                }

                outputPort.Handle(new PutResponse<Domain.Entities.WorkOrderEntity>(response.Model, true));
                return true;
            }

            outputPort.Handle(new PutResponse<Domain.Entities.WorkOrderEntity>(response.Errors));
            return false;
        }
    }
}
