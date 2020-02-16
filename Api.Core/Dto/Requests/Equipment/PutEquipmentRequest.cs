using Api.Core.Dto.Responses.Equipment;
using Api.Core.Interfaces;

namespace Api.Core.Dto.Requests.Equipment
{
    public class PutEquipmentRequest : IRequest<PutEquipmentResponse>
    {
        public Domain.Entities.Equipment Equipment { get; }
        public PutEquipmentRequest(Domain.Entities.Equipment equipment)
        {
            Equipment = equipment;
        }
    }
}
