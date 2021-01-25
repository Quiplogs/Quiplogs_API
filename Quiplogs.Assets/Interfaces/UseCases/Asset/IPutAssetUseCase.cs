using Quiplogs.Assets.Dto.Requests.Asset;
using Quiplogs.Assets.Dto.Responses.Asset;
using Quiplogs.Core.Interfaces;

namespace Quiplogs.Assets.Interfaces.UseCases.Asset
{
    public interface IPutAssetUseCase : IRequestHandler<PutAssetRequest, PutAssetResponse>
    {
    }
}
