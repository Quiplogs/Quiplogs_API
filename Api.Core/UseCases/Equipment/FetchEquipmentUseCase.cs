using Api.Core.Domain.Entities;
using Api.Core.Dto;
using Api.Core.Dto.Requests.Equipment;
using Api.Core.Dto.Responses.Equipment;
using Api.Core.Interfaces;
using Api.Core.Interfaces.Repositories.Equipment;
using Api.Core.Interfaces.UseCases.Equipment;
using System.Threading.Tasks;

namespace Api.Core.UseCases.Equipment
{
    public class FetchEquipmentUseCase : IFetchEquipmentUseCase
    {
        private readonly IEquipmentRepository _equipmentRepository;

        public FetchEquipmentUseCase(IEquipmentRepository equipmentRepository)
        {
            _equipmentRepository = equipmentRepository;
        }

        public async Task<bool> Handle(FetchEquipmentRequest message, IOutputPort<FetchEquipmentResponse> outputPort)
        {
            //temp var
            var pageSize = 20;

            var response = await _equipmentRepository.GetAll(message.CompanyId, message.LocationId, message.PageNumber, pageSize);
            if (response.Success)
            {
                var total = await _equipmentRepository.GetTotalRecords(message.CompanyId);
                var pagedResult = new PagedResult<Domain.Entities.Equipment>(response.Equipment, total, message.PageNumber, pageSize);

                outputPort.Handle(new FetchEquipmentResponse(pagedResult, true));
                return true;
            }

            outputPort.Handle(new FetchEquipmentResponse(new[] { new Error(GlobalVariables.error_equipmentFailure, "No Equipment Found.") }));
            return false;
        }
    }
}
