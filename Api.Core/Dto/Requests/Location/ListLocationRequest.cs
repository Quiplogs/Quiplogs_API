using System;
using Quiplogs.Core.Dto.Responses.Location;
using Quiplogs.Core.Interfaces;

namespace Quiplogs.Core.Dto.Requests.Location
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
