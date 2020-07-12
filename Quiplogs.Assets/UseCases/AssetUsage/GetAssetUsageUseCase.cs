using Api.Core;
using Api.Core.Dto;
using Api.Core.Interfaces;
using Quiplogs.Assets.Dto.Requests.AssetUsage;
using Quiplogs.Assets.Dto.Responses.AssetUsage;
using Quiplogs.Assets.Interfaces.Repositories;
using Quiplogs.Assets.Interfaces.UseCases.AssetUsage;
using System.Threading.Tasks;

namespace Quiplogs.Assets.UseCases.AssetUsage
{
    public class GetAssetUsageUseCase : IGetAssetUsageUseCase
    {
        private readonly IAssetUsageRepository _repository;

        public GetAssetUsageUseCase(IAssetUsageRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(GetAssetUsageRequest message, IOutputPort<GetAssetUsageResponse> outputPort)
        {
            var response = await _repository.Get(message.Id);
            if (response.Success)
            {
                outputPort.Handle(new GetAssetUsageResponse(response.AssetUsage, true));
                return true;
            }

            outputPort.Handle(new GetAssetUsageResponse(new[] { new Error(GlobalVariables.error_assetUsageFailure, "Asset Usage not Found.") }));
            return false;
        }
    }
}
