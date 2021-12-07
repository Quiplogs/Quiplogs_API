using Quiplogs.Assets.Dto.Responses.AssetUsage;
using System;
using Quiplogs.Core.Interfaces;

namespace Quiplogs.Assets.Dto.Requests.AssetUsage
{
    public class PutAssetUsageRequest : IRequest<PutAssetUsageResponse>
    {
        public decimal WorkDone { get; set; }

        public DateTime? DateCaptured { get; set; }

        public string AssetId { get; set; }

        public PutAssetUsageRequest(decimal workDone, DateTime? dateCaptured, string assetId)
        {
            WorkDone = workDone;
            DateCaptured = dateCaptured;
            AssetId = assetId;
        }
    }
}
