using Api.Core.Dto.Responses.Location;
using Api.Core.Interfaces;
using System;

namespace Api.Core.Dto.Requests.Location
{
    public class ListLocationRequest : IRequest<ListLocationResponse>
    {
        public Guid CompanyId { get; }
        public int PageNumber { get; }
        public string FilterName { get; }
        public ListLocationRequest(Guid companyId, int pageNumber, string filterName)
        {
            CompanyId = companyId;
            PageNumber = pageNumber;
            FilterName = filterName;
        }
    }
}
