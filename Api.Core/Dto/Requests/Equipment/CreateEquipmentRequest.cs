using Api.Core.Dto.Responses.Equipment;
using Api.Core.Interfaces;

namespace Api.Core.Dto.Requests.Equipment
{
    public class CreateEquipmentRequest : IRequest<CreateEquipmentResponse>
    {
        public Domain.Entities.Equipment Equipment { get; }
        public CreateEquipmentRequest(Domain.Entities.Equipment equipment)
        {
            Equipment = equipment;
        }
    }
}
