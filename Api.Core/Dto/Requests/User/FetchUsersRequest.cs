using Api.Core.Dto.Responses.User;
using Api.Core.Interfaces;
using System;

namespace Api.Core.Dto.Requests.User
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
