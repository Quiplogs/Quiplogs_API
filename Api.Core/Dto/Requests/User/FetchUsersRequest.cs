using Api.Core.Dto.Responses.User;
using Api.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Core.Dto.Requests.User
{
    public class FetchUsersRequest : IRequest<FetchUsersResponse>
    {
        public string CompanyId { get; }
        public string LocationId { get; }
        public FetchUsersRequest(string companyId, string locationId)
        {
            CompanyId = companyId;
            LocationId = locationId;
        }
    }
}
