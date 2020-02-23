using Api.Core.Interfaces;
using Quiplogs.Assets.Dto.Responses.Asset;

namespace Quiplogs.Assets.Dto.Requests.Asset
{
    public class FetchAssetRequest : IRequest<FetchAssetResponse>
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
