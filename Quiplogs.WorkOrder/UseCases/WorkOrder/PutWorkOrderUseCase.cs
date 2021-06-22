using System;
using System.Linq;
using Quiplogs.Core.Dto.Requests.Generic;
using Quiplogs.Core.Dto.Responses.Generic;
using Quiplogs.Core.Interfaces;
using Quiplogs.Core.Interfaces.Repositories;
using Quiplogs.Core.Interfaces.UseCases.Generic;
using Quiplogs.WorkOrder.Data.Entities;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Quiplogs.Core.Dto;
using Quiplogs.WorkOrder.Domain.Entities.Notifications;
using Quiplogs.WorkOrder.Interfaces.Services;

namespace Quiplogs.WorkOrder.UseCases.WorkOrder
{
    public class PutWorkOrderUseCase : IPutUseCase<Domain.Entities.WorkOrderEntity, WorkOrderDto>
    {
        private readonly IBaseRepository<Domain.Entities.WorkOrderEntity, WorkOrderDto> _baseRepository;
        private readonly INotificationService _notificationService;

        public PutWorkOrderUseCase(INotificationService notificationService,
            IBaseRepository<Domain.Entities.WorkOrderEntity,
                WorkOrderDto> baseRepository)
        {
            _baseRepository = baseRepository;
            _notificationService = notificationService;
        }

        public async Task<bool> Handle(PutRequest<Domain.Entities.WorkOrderEntity> request, IOutputPort<PutResponse<Domain.Entities.WorkOrderEntity>> outputPort)
        {
            //// Check if existing model with same ReferenceNumber
            //var getExistingResponse = await _baseRepository.GetByCustomWhere(where => where.ReferenceNumber.Contains(request.Model.ReferenceNumber));
            //if (getExistingResponse.Success)
            //{
            //    outputPort.Handle(new PutResponse<Domain.Entities.WorkOrderEntity>(new[] { new Error("exists", $"Work Order with Reference Number: '{request.Model.ReferenceNumber}' already exists.") }));
            //    return false;
            //}

            var technicianHasChanged = false;
            var initialId = request.Model?.Id ?? Guid.Empty;

            //Set unnecessary models to null & set company Ids
            request.Model.Company = null;
            request.Model.WorkOrderParts?.ForEach(workOrderPart =>
            {
                workOrderPart.CompanyId = request.Model.CompanyId;
                workOrderPart.Part = null;
            });

            request.Model.WorkOrderTasks?.ForEach(task => task.CompanyId = request.Model.CompanyId);

            //If exists then check if tech has changed and send mail
            if (initialId != Guid.Empty)
            {
                var getResponse = await _baseRepository.GetById(initialId);
                if (getResponse.Model.TechnicianId != request.Model.TechnicianId)
                {
                    technicianHasChanged = true;
                }
            }

            var response = await _baseRepository.Put(request.Model);
            if (response.Success)
            {
                // try send mail
                try
                {
                    if (technicianHasChanged || initialId == Guid.Empty)
                    {
                        var getResponse = await _baseRepository.GetById(response.Model.Id,
                            source =>
                                source.Include(model => model.Technician));

                        await _notificationService.SendMail(new WorkOrderEmailTemplate(getResponse.Model));
                    }
                }
                catch (Exception ex)
                {
                    // Log error
                }

                outputPort.Handle(new PutResponse<Domain.Entities.WorkOrderEntity>(response.Model, true));
                return true;
            }

            outputPort.Handle(new PutResponse<Domain.Entities.WorkOrderEntity>(response.Errors));
            return false;
        }
    }
}
