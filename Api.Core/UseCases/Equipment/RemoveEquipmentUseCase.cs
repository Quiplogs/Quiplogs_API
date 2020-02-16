using Api.Core.Dto;
using Api.Core.Dto.Requests.Equipment;
using Api.Core.Dto.Responses.Equipment;
using Api.Core.Interfaces;
using Api.Core.Interfaces.Repositories;
using Api.Core.Interfaces.UseCases.Equipment;
using System.Threading.Tasks;

namespace Api.Core.UseCases.Equipment
{
    public class RemoveEquipmentUseCase : IRemoveEquipmentUseCase
    {
        private readonly IEquipmentRepository _repository;

        public RemoveEquipmentUseCase(IEquipmentRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(RemoveEquipmentRequest message, IOutputPort<RemoveEquipmentResponse> outputPort)
        {
            var response = await _repository.Remove(message.Id);
            if (response.Success)
            {
                outputPort.Handle(new RemoveEquipmentResponse(response.EquipmentDescription, true));
                return true;
            }

            outputPort.Handle(new RemoveEquipmentResponse(new[] { new Error(GlobalVariables.error_equipmentFailure, "Error removing Equipment.") }));
            return false;
        }
    }
}
