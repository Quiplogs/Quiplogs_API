using Api.Core.Dto.Responses.Equipment;
using Api.Core.Interfaces;

namespace Api.Core.Dto.Requests.Equipment
{
    public class GetEquipmentRequest : IRequest<GetEquipmentResponse>
    {
        public string Id { get; }
        public GetEquipmentRequest(string id)
        {
            Id = id;
        }
    }
}
