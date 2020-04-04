using Api.Core.Dto.Responses.Location;
using Api.Core.Interfaces;

namespace Api.Core.Dto.Requests.Location
{
    public class ListLocationRequest : IRequest<ListLocationResponse>
    {
        public string CompanyId { get; }
        public int PageNumber { get; }
        public string FilterName { get; }
        public ListLocationRequest(string companyId, int pageNumber, string filterName)
        {
            CompanyId = companyId;
            PageNumber = pageNumber;
            FilterName = filterName;
        }
    }
}
