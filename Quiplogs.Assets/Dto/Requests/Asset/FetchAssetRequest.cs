using Api.Core.Interfaces;
using Quiplogs.Core.Dto.Responses.Generic;

namespace Quiplogs.Assets.Dto.Requests.Asset
{
    public class FetchAssetRequest : IRequest<GetResponse<Domain.Entities.Asset>>
    {
        public string CompanyId { get; }
        public string LocationId { get; }
        public int PageNumber { get; }

        public FetchAssetRequest(string companyId, string locationId, int pageNumber)
        {
            CompanyId = companyId;
            LocationId = locationId;
            PageNumber = pageNumber;
        }
    }
}
