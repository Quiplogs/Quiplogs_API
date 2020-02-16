using Api.Core.Dto.Responses.Part;
using Api.Core.Interfaces;

namespace Api.Core.Dto.Requests.Part
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
