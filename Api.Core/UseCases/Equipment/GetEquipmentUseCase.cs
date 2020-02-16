using Api.Core.Dto;
using Api.Core.Dto.Requests.Equipment;
using Api.Core.Dto.Responses.Equipment;
using Api.Core.Interfaces;
using Api.Core.Interfaces.Repositories;
using Api.Core.Interfaces.UseCases.Equipment;
using System.Threading.Tasks;

namespace Api.Core.UseCases.Equipment
{
    public class GetEquipmentUseCase : IGetEquipmentUseCase
    {
        private readonly IEquipmentRepository _repository;

        public GetEquipmentUseCase(IEquipmentRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(GetEquipmentRequest message, IOutputPort<GetEquipmentResponse> outputPort)
        {
            var response = await _repository.Get(message.Id);
            if (response.Success)
            {
                outputPort.Handle(new GetEquipmentResponse(response.Equipment, true));
                return true;
            }

            outputPort.Handle(new GetEquipmentResponse(new[] { new Error(GlobalVariables.error_equipmentFailure, "Equipment not Found.") }));
            return false;
        }
    }
}
