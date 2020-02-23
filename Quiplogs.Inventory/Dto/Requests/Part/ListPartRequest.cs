using Api.Core.Interfaces;
using Quiplogs.Inventory.Dto.Responses.Part;

namespace Quiplogs.Inventory.Dto.Requests.Part
{
    public class ListPartRequest : IRequest<ListPartResponse>
    {
        public string CompanyId { get; }
        public int PageNumber { get; }
        public ListPartRequest(string companyId, int pageNumber)
        {
            CompanyId = companyId;
            PageNumber = pageNumber;
        }
    }
}
