using Quiplogs.Assets.Dto.Requests.AssetUsage;
using Quiplogs.Assets.Dto.Responses.AssetUsage;
using Quiplogs.Core.Interfaces;

namespace Quiplogs.Assets.Interfaces.UseCases.AssetUsage
{
    public interface IGetAssetUsageUseCase : IRequestHandler<GetAssetUsageRequest, GetAssetUsageResponse>
    {
    }
}
