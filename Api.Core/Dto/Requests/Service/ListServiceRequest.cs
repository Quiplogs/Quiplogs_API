using Api.Core.Dto.Responses.Service;
using Api.Core.Interfaces;

namespace Api.Core.Dto.Requests.Service
{
    public class ListServiceRequest : IRequest<ListServiceResponse>
    {
        public string CompanyId { get; }
        public string LocationId { get; }
        public int PageNumber { get; }
        public ListServiceRequest(string companyId, string locationId, int pageNumber)
        {
            CompanyId = companyId;
            LocationId = locationId;
            PageNumber = pageNumber;
        }
    }
}
