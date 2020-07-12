using Api.Core.Interfaces;
using Quiplogs.Assets.Dto.Requests.AssetUsage;
using Quiplogs.Assets.Dto.Responses.AssetUsage;

namespace Quiplogs.Assets.Interfaces.UseCases.AssetUsage
{
    public interface IPutAssetUsageUseCase : IRequestHandler<PutAssetUsageRequest, PutAssetUsageResponse>
    {
    }
}
