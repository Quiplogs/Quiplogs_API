using System;
using System.Collections.Generic;
using Quiplogs.Core.Domain.Entities;
using Quiplogs.Core.Dto.Responses.Generic;
using Quiplogs.Core.Interfaces;

namespace Quiplogs.Core.Dto.Requests.Generic
{
    public class PagedRequest<T> : IRequest<PagedResponse<T>> where T : BaseEntity
    {
        public Guid CompanyId { get; }
        public Guid? LocationId { get; }
        public int PageNumber { get; }
        public int PageSize { get; }
        public Dictionary<string, string> FilterParameters { get; set; }

        public PagedRequest(Guid companyId, Guid? locationId,  int pageNumber, int pageSize, Dictionary<string, string> filterParameters)
        {
            CompanyId = companyId;
            LocationId = locationId;
            PageNumber = pageNumber;
            PageSize = pageSize;
            FilterParameters = filterParameters;
        }
    }
}
