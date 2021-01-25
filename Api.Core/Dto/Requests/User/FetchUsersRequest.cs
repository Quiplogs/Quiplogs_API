using System;
using Quiplogs.Core.Dto.Responses.User;
using Quiplogs.Core.Interfaces;

namespace Quiplogs.Core.Dto.Requests.User
{
    public class FetchUsersRequest : IRequest<FetchUsersResponse>
    {
        public Guid CompanyId { get; }
        public Guid LocationId { get; }
        public FetchUsersRequest(Guid companyId, Guid locationId)
        {
            CompanyId = companyId;
            LocationId = locationId;
        }
    }
}
