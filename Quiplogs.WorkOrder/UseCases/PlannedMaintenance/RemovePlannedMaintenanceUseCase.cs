﻿using Api.Core;
using Api.Core.Dto;
using Api.Core.Interfaces;
using Quiplogs.PlannedMaintenance.Interfaces.UseCases.PlannedMaintenance;
using Quiplogs.WorkOrder.Dto.Requests.PlannedMaintenance;
using Quiplogs.WorkOrder.Dto.Responses.PlannedMaintenance;
using Quiplogs.WorkOrder.Interfaces.Repositories;
using System.Threading.Tasks;

namespace Quiplogs.WorkOrder.UseCases.PlannedMaintenance
{
    public class RemovePlannedMaintenanceUseCase : IRemovePlannedMaintenanceUseCase
    {
        private readonly IPlannedMaintenanceRepository _repository;

        public RemovePlannedMaintenanceUseCase(IPlannedMaintenanceRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(RemovePlannedMaintenanceRequest message, IOutputPort<RemovePlannedMaintenanceResponse> outputPort)
        {
            var response = await _repository.Remove(message.Id);
            if (response.Success)
            {
                outputPort.Handle(new RemovePlannedMaintenanceResponse(response.Description, true));
                return true;
            }

            outputPort.Handle(new RemovePlannedMaintenanceResponse(new[] { new Error(GlobalVariables.error_plannedMaintenanceFailure, "Error removing Planned Maintenance.") }));
            return false;
        }
    }
}