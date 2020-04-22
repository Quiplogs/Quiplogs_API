using Api.Core.Interfaces;
using Quiplogs.Inventory.Dto.Responses.Part;

namespace Quiplogs.Inventory.Dto.Requests.Part
{
    public class ListPartRequest : IRequest<ListPartResponse>
    {
        public string CompanyId { get; }
        public string LocationId { get; }
        public int PageNumber { get; }
        public string FilterName { get; set; }

        public ListPartRequest(string companyId, string locationId, string filterName, int pageNumber)
        {
            CompanyId = companyId;
            LocationId = locationId;
            FilterName = filterName;
            PageNumber = pageNumber;
        }
    }
}
