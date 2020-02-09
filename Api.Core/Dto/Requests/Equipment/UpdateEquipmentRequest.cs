using Api.Core.Dto.Responses.Equipment;
using Api.Core.Interfaces;

namespace Api.Core.Dto.Requests.Equipment
{
    public class UpdateEquipmentRequest : IRequest<UpdateEquipmentResponse>
    {
        public Domain.Entities.Equipment Equipment { get; }
        public UpdateEquipmentRequest(Domain.Entities.Equipment equipment)
        {
            Equipment = equipment;
        }
    }
}
