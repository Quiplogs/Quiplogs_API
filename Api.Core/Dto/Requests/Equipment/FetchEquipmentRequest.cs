using Api.Core.Dto.Responses.Equipment;
using Api.Core.Interfaces;

namespace Api.Core.Dto.Requests.Equipment
{
    public class FetchEquipmentRequest : IRequest<FetchEquipmentResponse>
    {
        public string CompanyId { get; }
        public string LocationId { get; }
        public int PageNumber { get; }
        public FetchEquipmentRequest(string companyId, string locationId, int pageNumber)
        {
            CompanyId = companyId;
            LocationId = locationId;
            PageNumber = pageNumber;
        }
    }
}
