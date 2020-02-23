using Api.Core.Interfaces;
using Quiplogs.Assets.Dto.Requests.Asset;
using Quiplogs.Assets.Dto.Responses.Asset;

namespace Quiplogs.Assets.Interfaces.UseCases.Asset
{
    public interface IGetAssetUseCase : IRequestHandler<GetAssetRequest, GetAssetResponse>
    {
    }
}
