using System;
using System.Collections.Generic;
using Quiplogs.Core.Dto.Responses.User;
using Quiplogs.Core.Interfaces;

namespace Quiplogs.Core.Dto.Requests.User
{
    public class FetchUsersRequest : IRequest<FetchUsersResponse>
    {
        public Guid CompanyId { get; }
        public Guid? LocationId { get; }
        public int PageSize { get; }
        public int PageNumber { get; }
        public Dictionary<string, string> FilterParameters { get; set; }
        public FetchUsersRequest(Guid companyId, Guid? locationId, int pageSize, int pageNumber, Dictionary<string, string> filterParameters)
        {
            CompanyId = companyId;
            LocationId = locationId;
            PageSize = pageSize;
            PageNumber = pageNumber;
            FilterParameters = filterParameters;
        }
    }
}
