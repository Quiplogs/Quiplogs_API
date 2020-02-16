using Api.Core.Dto;
using Api.Core.Dto.Requests.Equipment;
using Api.Core.Dto.Responses.Equipment;
using Api.Core.Interfaces;
using Api.Core.Interfaces.Repositories;
using Api.Core.Interfaces.UseCases.Equipment;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Api.Core.UseCases.Equipment
{
    public class PutEquipmentUseCase : IPutEquipmentUseCase
    {
        private readonly IEquipmentRepository _repository;

        public PutEquipmentUseCase(IEquipmentRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(PutEquipmentRequest message, IOutputPort<PutEquipmentResponse> outputPort)
        {
            var response = await _repository.Put(message.Equipment);
            if (response.Success)
            {
                outputPort.Handle(new PutEquipmentResponse(response.Equipment, true));
                return true;
            }

            outputPort.Handle(new PutEquipmentResponse(new[] { new Error(GlobalVariables.error_equipmentFailure, "Error updating equipment.") }));
            return false;
        }
    }
}
