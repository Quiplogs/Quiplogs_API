using Api.Core.Interfaces;
using Quiplogs.Inventory.Dto.Responses.Part;
using System;

namespace Quiplogs.Inventory.Dto.Requests.Part
{
    public class ListPartRequest : IRequest<ListPartResponse>
    {
        public Guid CompanyId { get; }
        public Guid LocationId { get; }
        public int PageNumber { get; }
        public string FilterName { get; set; }

        public ListPartRequest(Guid companyId, Guid locationId, string filterName, int pageNumber)
        {
            CompanyId = companyId;
            LocationId = locationId;
            FilterName = filterName;
            PageNumber = pageNumber;
        }
    }
}
