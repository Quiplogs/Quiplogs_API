using Api.Core.Dto.Responses.Equipment;
using Api.Core.Interfaces;

namespace Api.Core.Dto.Requests.Equipment
{
    public class RemoveEquipmentRequest : IRequest<RemoveEquipmentResponse>
    {
        public string Id { get; }
        public RemoveEquipmentRequest(string id)
        {
            Id = id;
        }
    }
}
